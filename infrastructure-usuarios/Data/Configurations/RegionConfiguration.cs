using System;
using System.Collections.Generic;
using System.Text;
using core_usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure_usuarios.Data.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(e => e.IdRegion)
                    .HasName("SYS_C007182");

            builder.ToTable("REGION");

            builder.Property(e => e.IdRegion)
                .HasColumnType("NUMBER(38)")
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_REGION");

            builder.Property(e => e.Region1)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("REGION");
        }
    }
}
