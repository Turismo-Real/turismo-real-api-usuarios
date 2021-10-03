using core_usuarios.Interfaces;
using infrastructure_usuarios.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace turismo_real_api_usuarios.Controllers
{
    [Route("api/[controller]")]
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
    }
}
