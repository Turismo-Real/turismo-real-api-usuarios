using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Usuarios.Core.DTOs;
using TurismoReal_Usuarios.Core.Interfaces;
using TurismoReal_Usuarios.Core.Log;
using TurismoReal_Usuarios.Core.Messages;

namespace TurismoReal_Usuarios.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioRepository;
        private readonly string serviceName = "turismo_real_usuarios";

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET /api/v1/usuarios
        [HttpGet]
        public async Task<IEnumerable<object>> GetUsuarios()
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "GET";
            log.endpoint = "/api/v1/usuario";
            DateTime startService = DateTime.Now;

            IEnumerable<UsuarioDTO> usuarios = await _usuarioRepository.GetUsuarios();

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = "Lista de usuarios";
            Console.WriteLine(log.parseJson());
            // LOG
            return usuarios;
        }

        // GET /api/v1/usuario/{id}
        [HttpGet("{id}")]
        public async Task<object> GetUsuario(int id)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "GET";
            log.endpoint = "/api/v1/usuario/{id}";
            log.payload = id;
            DateTime startService = DateTime.Now;

            var usuario = await _usuarioRepository.GetUsuario(id);

            if (usuario == null)
            {
                return new BadResponse($"No se encontró usuario con id {id}");
            }

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = usuario;
            Console.WriteLine(log.parseJson());
            // LOG

            return usuario;
        }

        // POST: /api/v1/usuario
        [HttpPost]
        public async Task<object> AddUsuario([FromBody] UsuarioDTO pyl)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "POST";
            log.endpoint = "/api/v1/usuario";
            log.payload = pyl;
            DateTime startService = DateTime.Now;
            UsuarioResponse response;

            int id = await _usuarioRepository.AddUsuario(pyl);

            if (id > 0)
            {
                UsuarioDTO usuario = await _usuarioRepository.GetUsuario(id);
                response = new UsuarioResponse("Usuario agregado.", true, usuario);

                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = usuario;
                Console.WriteLine(log.parseJson());
                // LOG
                return response;
            }
            response = new UsuarioResponse("Error al agregar usuario.", false, null);

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = response;
            Console.WriteLine(log.parseJson());
            // LOG

            return response;
        }

        // PUT: /api/v1/usuario/{id}
        [HttpPut("{id}")]
        public async Task<object> UpdateUsuario(int id, [FromBody] UsuarioDTO usuario)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "PUT";
            log.endpoint = "/api/v1/usuario/{id}";
            log.parameters.Add(id.ToString());
            log.payload = usuario;
            DateTime startService = DateTime.Now;

            int user_id = await _usuarioRepository.UpdateUsuario(id, usuario);

            if (user_id == -1) return new { message = $"No se encontró usuario con ID {id}", updated = false };
            if (user_id > 0)
            {
                UsuarioDTO updatedUser = await _usuarioRepository.GetUsuario(user_id);

                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = updatedUser;
                Console.WriteLine(log.parseJson());
                return new { message = "Usuario actualizado.", updated = true, usuario = updatedUser };
            }
            object response = new { message = "Error al modificar el usuario.", updated = false };
            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = response;
            Console.WriteLine(log.parseJson());
            // LOG
            return response;
        }

        // DELETE: /api/v1/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<object> DeleteUsuario(int id)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "DELETE";
            log.endpoint = "/api/v1/usuario/{id}";
            log.payload = id;
            DateTime startService = DateTime.Now;
            DeleteResponseOK response;

            int removed = await _usuarioRepository.DeleteUsuario(id);

            if (removed == 1)
            {
                response = new DeleteResponseOK("Usuario eliminado.", true);
            }
            else if(removed < 0)
            {
                response = new DeleteResponseOK($"No existe el usuario con id {id}", false);
            }
            else
            {
                response = new DeleteResponseOK("Error al eliminar usuario.", false);
            }
            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = response;
            Console.WriteLine(log.parseJson());
            // LOG
            return response;
        }

        // PATCH: /api/v1/usuario/{id}
        [HttpPatch("{id}")]
        public async Task<object> UpdatePassword(int id, [FromBody] PasswordPayload password)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "PATCH";
            log.endpoint = "/api/v1/usuario/{id}";
            log.payload = id;
            DateTime startService = DateTime.Now;

            int result = await _usuarioRepository.UpdatePassword(id, password);

            string message;
            if (result == -1)
            {
                message = $"No existe el usuario con id {id}.";
                var responseNotFound = new { message, updated = false };
                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseNotFound;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseNotFound;
            }

            if (result == -2)
            {
                message = "La contraseña enviada no coincide con la actual.";
                var responseBadPassword = new { message, updated = false };
                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseBadPassword;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseBadPassword;
            }

            if (result == 0)
            {
                message = "Error al actualizar contraseña.";
                var responseError = new { message, updated = false };
                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseError;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseError;
            }
            message = "Contraseña actualizada.";
            var responseOK = new { message, updated = true };
            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = responseOK;
            Console.WriteLine(log.parseJson());
            // LOG
            return responseOK;
        }
    }
}
