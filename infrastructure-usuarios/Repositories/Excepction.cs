using System;
using System.Runtime.Serialization;

namespace infrastructure_usuarios.Repositories
{
    [Serializable]
    internal class Excepction : Exception
    {
        public Excepction()
        {
        }

        public Excepction(string message) : base(message)
        {
        }

        public Excepction(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Excepction(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}