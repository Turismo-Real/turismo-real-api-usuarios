using System;
using System.Collections.Generic;

#nullable disable

namespace core_usuarios.Entities
{
    public partial class Direccion
    {
        public decimal IdDireccion { get; set; }
        public decimal? IdDepartamento { get; set; }
        public string Numrut { get; set; }
        public decimal IdComuna { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Depto { get; set; }
        public string Casa { get; set; }

        public virtual Comuna IdComunaNavigation { get; set; }
        public virtual Usuario NumrutNavigation { get; set; }
    }
}
