using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.Data.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.DateCreated);
            builder.Property(x => x.Tittle).HasMaxLength(200);
            builder.Property(x => x.Content).HasMaxLength(2000);
            builder.Property(x => x.ImageURL).HasMaxLength(200);
        }
    }
}
