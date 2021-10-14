namespace TurismoReal_Usuarios.Core.Messages
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
