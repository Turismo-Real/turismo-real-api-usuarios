using System;

namespace turismo_real_api_usuarios.Log
{
    public class LogModel
    {
        public string level = "INFO";
        public int statusCode = 0;
        public string servicio = string.Empty;
        public string method = string.Empty;
        public string endpoint = string.Empty;
        public DateTime inicioSolicitud;
        public DateTime finSolicitud;
        public string tiempoSolicitud;
        public object payload = null;
        public object response = null;

        public string parseJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this) + "\n";
        }

    }
}
