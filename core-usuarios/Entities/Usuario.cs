using System;
using System.Collections.Generic;

#nullable disable

namespace core_usuarios.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            DireccionUsuario = new HashSet<Direccion>();
        }

        public string Numrut { get; set; }
        public string Dvrut { get; set; }
        public string Pnombre { get; set; }
        public string Snombre { get; set; }
        public string Apepat { get; set; }
        public string Apemat { get; set; }
        public DateTime FecNac { get; set; }
        public string Correo { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoFijo { get; set; }
        public string Password { get; set; }
        public decimal IdGenero { get; set; }
        public decimal IdPais { get; set; }
        public decimal IdTipo { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Pais IdPaisNavigation { get; set; }
        public virtual TipoUsuario IdTipoNavigation { get; set; }
        public virtual IEnumerable<Direccion> DireccionUsuario { get; set; }
    }
}
