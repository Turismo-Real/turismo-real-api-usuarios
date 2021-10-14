namespace TurismoReal_Usuarios.Core.Messages
{
    public class DeleteResponseOK
    {
        public DeleteResponseOK() { }
        public DeleteResponseOK(string message, bool removed)
        {
            this.message = message;
            this.removed = removed;
        }

        public string message { get; set; }
        public bool removed { get; set; }
    }
}
