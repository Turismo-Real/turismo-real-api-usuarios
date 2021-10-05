using System;
using System.Collections.Generic;
using System.Text;

namespace core_usuarios.Messages
{
    public class UsuarioResponse
    {
        public UsuarioResponse() { }
        public UsuarioResponse(string message)
        {
            this.message = message;
        }
        public string message { get; set; }
    }
}
