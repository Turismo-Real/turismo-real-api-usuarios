using System;
using System.Collections.Generic;
using System.Text;

namespace core_usuarios.Messages
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
