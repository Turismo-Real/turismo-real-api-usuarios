using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TurismoReal_Usuarios.Core.DTOs;

namespace TurismoReal_Usuarios.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioDTO>> GetUsuarios();

        Task<UsuarioDTO> GetUsuario(string rut);

        Task<bool> AddUsuario(UsuarioDTO usuario);

        Task<bool> DeleteUsuario(string rut);
    }
}
