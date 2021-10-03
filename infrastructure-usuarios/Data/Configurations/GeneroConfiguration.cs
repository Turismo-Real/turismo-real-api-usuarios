using System;
using System.Collections.Generic;
using System.Text;
using core_usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure_usuarios.Data.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(e => e.IdGenero)
                    .HasName("SYS_C007167");

            builder.ToTable("GENERO");

            builder.Property(e => e.IdGenero)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_GENERO");

            builder.Property(e => e.Genero1)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GENERO");
        }
    }
}
