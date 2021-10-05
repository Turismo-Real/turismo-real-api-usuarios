using core_usuarios.DTOs;
using core_usuarios.Interfaces;
using core_usuarios.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<object> AddUsuario([FromBody]UsuarioDTO pyl)
        {
            bool result = await _usuarioRepository.AddUsuario(pyl);

            if (result)
                return new UsuarioResponse("Usuario agregado.");
            return new UsuarioResponse("Error al agregar usuario");

        }
    }
}
