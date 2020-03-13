using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Auth;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.EntitiesLayer.Entities.NmNews;
using Tech.Between.We.EntitiesLayer.Entities.Persons;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.Mappers.NmNews;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.DbContexts
{
  public  class WeDbContext:DbContext
    {
        public WeDbContext() : base() { }

        public WeDbContext(string connectionString) : base(GetOptions(connectionString)) { }

        public WeDbContext(DbContextOptions<WeDbContext> options) : base(options) { }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=.;Initial Catalog=WeDb;Persist Security Info=False;User ID=sa;Password=12345;MultipleActiveResultSets=False;Connection Timeout=30;");
#else
            optionsBuilder
              .UseLazyLoadingProxies();
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new NewsMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var res = -1;
            try
            {
                var selectedEntityList = ChangeTracker.Entries()
                                                        .Where(x => x.Entity is EntityBase &&
                                                                    x.State == EntityState.Added).ToList();

                selectedEntityList.ForEach(entity => {
                    if (entity.State == EntityState.Added)
                    {
                        ((EntityBase)entity.Entity).DbInsertedDate = DateTime.Now;
                    }
                });
                res = base.SaveChanges();
            }
            catch (Exception exp)
            {
                throw exp;
            }


            return res;
        }

        public T ReloadEntity<T>(T entityBase) where T : EntityBase
        {

            try
            {
                var entities = this.ChangeTracker.Entries().ToList();
                entities?.ForEach(e => e.State = EntityState.Detached);
                var res = (T)this.Set<T>().Find(entityBase.Id);
                return res;
            }
            catch (Exception exp)
            {

            }
            return null;
        }


        public DbSet<News> News { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Login> Logins { get; set; }

    }
}
