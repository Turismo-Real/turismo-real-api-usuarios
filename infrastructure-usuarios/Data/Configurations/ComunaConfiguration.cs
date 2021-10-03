using System;
using System.Collections.Generic;
using System.Text;
using core_usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure_usuarios.Data.Configurations
{
    public class ComunaConfiguration : IEntityTypeConfiguration<Comuna>
    {
        public void Configure(EntityTypeBuilder<Comuna> entity)
        {
            entity.HasKey(e => e.IdComuna)
                    .HasName("SYS_C007186");

            entity.ToTable("COMUNA");

            entity.Property(e => e.IdComuna)
                .HasColumnType("NUMBER(38)")
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_COMUNA");

            entity.Property(e => e.Comuna1)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COMUNA");

            entity.Property(e => e.IdRegion)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_REGION");

            entity.HasOne(d => d.IdRegionNavigation)
                .WithMany(p => p.Comunas)
                .HasForeignKey(d => d.IdRegion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMUNA_REGION");
        }
    }
}
