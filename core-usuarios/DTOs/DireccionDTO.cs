using System;
using System.Collections.Generic;
using System.Text;

namespace core_usuarios.DTOs
{
    public class DireccionDTO
    {
        public string region { get; set; }
        public string comuna { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string depto { get; set; }
        public string casa { get; set; }
    }
}
