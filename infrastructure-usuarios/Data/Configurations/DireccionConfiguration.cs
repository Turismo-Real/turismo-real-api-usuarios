using System;
using System.Collections.Generic;
using System.Text;
using core_usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure_usuarios.Data.Configurations
{
    public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.HasKey(e => e.IdDireccion)
                    .HasName("SYS_C007237");

            builder.ToTable("DIRECCION");

            builder.Property(e => e.IdDireccion)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_DIRECCION");

            builder.Property(e => e.Calle)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CALLE");

            builder.Property(e => e.Casa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CASA");

            builder.Property(e => e.Depto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPTO");

            builder.Property(e => e.IdComuna)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_COMUNA");

            builder.Property(e => e.IdDepartamento)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_DEPARTAMENTO");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NUMERO");

            builder.Property(e => e.Numrut)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("NUMRUT");

            builder.HasOne(d => d.IdComunaNavigation)
                .WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdComuna)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DIRECCION_COMUNA");

            builder.HasOne(d => d.NumrutNavigation)
                .WithMany(p => p.Direccions)
                .HasForeignKey(d => d.Numrut)
                .HasConstraintName("FK_DIRECCION_USUARIO");
        }
    }
}
