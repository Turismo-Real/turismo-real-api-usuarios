using System;
using System.Collections.Generic;
using System.Text;
using core_usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure_usuarios.Data.Configurations
{
    public class TipoUsuarioConfiguration : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.HasKey(e => e.IdTipo)
                    .HasName("SYS_C007161");

            builder.ToTable("TIPO_USUARIO");

            builder.Property(e => e.IdTipo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TIPO");

            builder.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        }
    }
}
