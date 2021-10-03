using System;
using core_usuarios.Entities;
using infrastructure_usuarios.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace infrastructure_usuarios.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comuna> Comunas { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST= (ADDRESS=(COMMUNITY=tcpcom.world)(PROTOCOL=tcp)(HOST=localhost)(PORT=49161)))(CONNECT_DATA=(SID=xe))); User ID=turismo_real;Password=portafolio");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TURISMO_REAL");

            modelBuilder.ApplyConfiguration(new ComunaConfiguration());
            modelBuilder.ApplyConfiguration(new DireccionConfiguration());
            modelBuilder.ApplyConfiguration(new GeneroConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new TipoUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            modelBuilder.HasSequence("SEQ_COMUNA");
            modelBuilder.HasSequence("SEQ_DIRECCION");
            modelBuilder.HasSequence("SEQ_GENERO");
            modelBuilder.HasSequence("SEQ_PAIS");
            modelBuilder.HasSequence("SEQ_REGION");
            modelBuilder.HasSequence("SEQ_TIPO_USUARIO");

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
