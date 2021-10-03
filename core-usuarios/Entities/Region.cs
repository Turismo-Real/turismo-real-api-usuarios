using System;
using System.Collections.Generic;

#nullable disable

namespace core_usuarios.Entities
{
    public partial class Region
    {
        public Region()
        {
            Comunas = new HashSet<Comuna>();
        }

        public decimal IdRegion { get; set; }
        public string Region1 { get; set; }

        public virtual ICollection<Comuna> Comunas { get; set; }
    }
}
