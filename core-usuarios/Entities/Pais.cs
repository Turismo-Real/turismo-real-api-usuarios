using System;
using System.Collections.Generic;

#nullable disable

namespace core_usuarios.Entities
{
    public partial class Pais
    {
        public Pais()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public decimal IdPais { get; set; }
        public string NombrePais { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
