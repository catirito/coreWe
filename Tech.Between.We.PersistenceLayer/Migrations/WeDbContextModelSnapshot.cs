﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.DbContexts;

namespace Tech.Between.We.PersistenceLayer.Migrations
{
    [DbContext(typeof(WeDbContext))]
    partial class WeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Auth.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Auth.RenewToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<DateTime?>("Expire");

                    b.Property<Guid?>("LoginId");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("RenewToken");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Auth.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("LoginId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Commons.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("ISO");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Nif");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.FileDatas.FileData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthKey");

                    b.Property<long?>("ConeixId");

                    b.Property<string>("ContentType");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("FileId");

                    b.Property<string>("Name");

                    b.Property<Guid?>("NewsId");

                    b.Property<long?>("Size");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("FileData");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId");

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("Date");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("NewsId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("NewsId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId");

                    b.Property<string>("Body");

                    b.Property<long?>("ConeixId");

                    b.Property<bool?>("Confidential");

                    b.Property<DateTime?>("Date");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("NewsSubTypeId");

                    b.Property<string>("Title")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("NewsSubTypeId");

                    b.ToTable("News","NEWS");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsSubType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("NewsTypeId");

                    b.HasKey("Id");

                    b.HasIndex("NewsTypeId");

                    b.ToTable("NewsSubType");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsSubTypeLiteral", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LanguageId");

                    b.Property<Guid?>("NewsSubTypeId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("NewsSubTypeId");

                    b.ToTable("NewsSubTypeLiteral");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.HasKey("Id");

                    b.ToTable("NewsType");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsTypeLiteral", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LanguageId");

                    b.Property<Guid?>("NewsTypeId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("NewsTypeId");

                    b.ToTable("NewsTypeLiteral");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags.NewsCompanyTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompanyId");

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("NewsId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("NewsId");

                    b.ToTable("NewsCompanyTag");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags.NewsPersonTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("NewsId");

                    b.Property<Guid?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("PersonId");

                    b.ToTable("NewsPersonTag");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags.NewsProjectTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("NewsId");

                    b.Property<Guid?>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("ProjectId");

                    b.ToTable("NewsProjectTag");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Persons.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.Property<string>("Surname2");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Persons.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<Guid?>("LanguageId");

                    b.Property<Guid?>("LoginId");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<Guid?>("PersonId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LoginId");

                    b.HasIndex("PersonId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Projects.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConeixId");

                    b.Property<DateTime?>("DbInsertedDate");

                    b.Property<long?>("DefaultOrder");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Reference");

                    b.Property<DateTime?>("RequestDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Auth.RenewToken", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Auth.Login")
                        .WithMany("RenewTokens")
                        .HasForeignKey("LoginId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Auth.Role", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Auth.Login")
                        .WithMany("Roles")
                        .HasForeignKey("LoginId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.FileDatas.FileData", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.News")
                        .WithMany("Files")
                        .HasForeignKey("NewsId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.Comment", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Persons.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.News")
                        .WithMany("Comments")
                        .HasForeignKey("NewsId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.News", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Persons.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsSubType", "NewsSubType")
                        .WithMany()
                        .HasForeignKey("NewsSubTypeId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsSubType", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsType", "NewsType")
                        .WithMany()
                        .HasForeignKey("NewsTypeId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsSubTypeLiteral", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Commons.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsSubType")
                        .WithMany("Literals")
                        .HasForeignKey("NewsSubTypeId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsTypeLiteral", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Commons.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.NewsType")
                        .WithMany("Literals")
                        .HasForeignKey("NewsTypeId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags.NewsCompanyTag", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Companies.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.News")
                        .WithMany("TaggedCompanies")
                        .HasForeignKey("NewsId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags.NewsPersonTag", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.News")
                        .WithMany("TaggedPeople")
                        .HasForeignKey("NewsId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Persons.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags.NewsProjectTag", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.NmNews.News")
                        .WithMany("TaggedProjects")
                        .HasForeignKey("NewsId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Tech.Between.We.EntitiesLayer.Entities.Persons.User", b =>
                {
                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Commons.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Auth.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId");

                    b.HasOne("Tech.Between.We.EntitiesLayer.Entities.Persons.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}