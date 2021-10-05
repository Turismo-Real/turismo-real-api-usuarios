using core_usuarios.DTOs;
using core_usuarios.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace core_usuarios.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();

        Task<UsuarioDTO> GetUsuario(string rut);

        Task<bool> AddUsuario(UsuarioDTO usuario);

        Task<bool> DeleteUsuario(string rut);
    }
}
