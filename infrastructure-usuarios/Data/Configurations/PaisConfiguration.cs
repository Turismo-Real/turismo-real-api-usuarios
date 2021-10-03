using System;
using System.Collections.Generic;
using System.Text;
using core_usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure_usuarios.Data.Configurations
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.HasKey(e => e.IdPais)
                    .HasName("SYS_C007164");

            builder.ToTable("PAIS");

            builder.Property(e => e.IdPais)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_PAIS");

            builder.Property(e => e.NombrePais)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PAIS");
        }
    }
}
