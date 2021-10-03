using System;
using System.Collections.Generic;

#nullable disable

namespace core_usuarios.Entities
{
    public partial class Genero
    {
        public Genero()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public decimal IdGenero { get; set; }
        public string Genero1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
