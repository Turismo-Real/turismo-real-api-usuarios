﻿using System;
using System.Collections.Generic;
using System.Text;

namespace core_usuarios.DTOs
{
    public class UsuarioDTO
    {
        public string rut { get; set; }
        public string dv { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string correo { get; set; }
        public string telefonoMovil { get; set; }
        public string telefonoFijo { get; set; }
        public string password { get; set; }
        public string genero { get; set; }
        public string pais { get; set; }
        public string tipoUsuario { get; set; }
        public DireccionDTO direccion { get; set; }
    }
}
