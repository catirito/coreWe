using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.NmNews;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.Mappers.NmNews
{
    class NewsMap : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News", "NEWS");
            builder.Property(e => e.Title).HasMaxLength(2000);

        }
    }
}
