using TurismoReal_Usuarios.Core.DTOs;

namespace TurismoReal_Usuarios.Core.Messages
{
    public class UsuarioResponse
    {
        public UsuarioResponse() { }
        public UsuarioResponse(string message, bool saved, UsuarioDTO usuario)
        {
            this.message = message;
            this.saved = saved;
            this.usuario = usuario;
        }
        public string message { get; set; }
        public bool saved { get; set; }
        public UsuarioDTO usuario { get; set; }
    }
}
