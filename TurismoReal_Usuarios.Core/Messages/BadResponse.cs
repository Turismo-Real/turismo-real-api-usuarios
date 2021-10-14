namespace TurismoReal_Usuarios.Core.Messages
{
    public class BadResponse
    {
        public BadResponse() { }
        public BadResponse(string message)
        {
            this.message = message;
        }

        public string message { get; set; }
    }
}
