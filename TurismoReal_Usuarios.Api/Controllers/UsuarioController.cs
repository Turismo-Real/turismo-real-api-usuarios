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
            log.endpoint = "/api/v1/usuario/{rut}";
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

            response = new UsuarioResponse("Error al agregar usuario.");

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
            log.method = "POST";
            log.endpoint = "/api/v1/usuario";
            log.payload = usuario;
            DateTime startService = DateTime.Now;

            int user_id = await _usuarioRepository.UpdateUsuario(id, usuario);
            if (user_id > 0)
            {
                UsuarioDTO newUser = await _usuarioRepository.GetUsuario(user_id);

                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = newUser;
                Console.WriteLine(log.parseJson());
                return newUser;
            }

            UsuarioResponse response = new UsuarioResponse("Error al modificar el usuario.");

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
            log.endpoint = "/api/v1/usuario/{rut}";
            DateTime startService = DateTime.Now;
            DeleteResponseOK response;

            bool removed = await _usuarioRepository.DeleteUsuario(id);

            if (removed)
            {
                response = new DeleteResponseOK("Usuario eliminado.", removed);
            }
            else
            {
                response = new DeleteResponseOK("Error al eliminar usuario.", removed);
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
    }
}
