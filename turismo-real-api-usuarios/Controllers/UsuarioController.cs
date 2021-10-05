using core_usuarios.DTOs;
using core_usuarios.Interfaces;
using core_usuarios.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using turismo_real_api_usuarios.Log;

namespace turismo_real_api_usuarios.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{rut}")]
        public async Task<IActionResult> GetUsuario(string rut)
        {
            var usuario = await _usuarioRepository.GetUsuario(rut);
            return Ok(usuario);
        }

        // POST: /api/v1/usuario
        [HttpPost]
        public async Task<object> AddUsuario([FromBody]UsuarioDTO pyl)
        {
            LogModel log = new LogModel();
            log.servicio = "turismo-real-api-usuarios";
            log.payload = pyl;
            DateTime startService = DateTime.Now;
            UsuarioResponse response;

            bool result = await _usuarioRepository.AddUsuario(pyl);

            if (result)
            {
                response = new UsuarioResponse("Usuario agregado.");
            } else {
                response = new UsuarioResponse("Error al agregar usuario.");
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

        // DELETE: /api/v1/usuario/{rut}
        [HttpDelete("{rut}")]
        public async Task<object> DeleteUsuario(string rut)
        {
            DeleteResponseOK response;
            bool removed = await _usuarioRepository.DeleteUsuario(rut);
            Console.WriteLine("REMOVED IN CONTROLLER: "+removed);
            return removed ? new DeleteResponseOK("Usuario eliminado.", removed) : new DeleteResponseOK("Error al eliminar usuario.", removed);
        }
    }
}
