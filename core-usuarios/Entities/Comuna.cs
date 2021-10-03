using System;
using System.Collections.Generic;

#nullable disable

namespace core_usuarios.Entities
{
    public partial class Comuna
    {
        public Comuna()
        {
            Direccions = new HashSet<Direccion>();
        }

        public decimal IdComuna { get; set; }
        public string Comuna1 { get; set; }
        public decimal IdRegion { get; set; }

        public virtual Region IdRegionNavigation { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
