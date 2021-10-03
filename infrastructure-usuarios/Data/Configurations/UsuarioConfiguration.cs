using System;
using System.Collections.Generic;
using System.Text;
using core_usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure_usuarios.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Numrut)
                    .HasName("SYS_C007250");

            builder.ToTable("USUARIO");

            builder.Property(e => e.Numrut)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("NUMRUT");

            builder.Property(e => e.Apemat)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APEMAT");

            builder.Property(e => e.Apepat)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APEPAT");

            builder.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");

            builder.Property(e => e.Dvrut)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DVRUT");

            builder.Property(e => e.FecNac)
                .HasColumnType("DATE")
                .HasColumnName("FEC_NAC");

            builder.Property(e => e.IdGenero)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_GENERO");

            builder.Property(e => e.IdPais)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_PAIS");

            builder.Property(e => e.IdTipo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TIPO");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");

            builder.Property(e => e.Pnombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PNOMBRE");

            builder.Property(e => e.Snombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SNOMBRE");

            builder.Property(e => e.TelefonoFijo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_FIJO");

            builder.Property(e => e.TelefonoMovil)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_MOVIL");

            builder.HasOne(d => d.IdGeneroNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_GENERO");

            builder.HasOne(d => d.IdPaisNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_PAIS");

            builder.HasOne(d => d.IdTipoNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIPO_USUARIO");
        }
    }
}
