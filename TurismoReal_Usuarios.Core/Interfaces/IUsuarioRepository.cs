using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TurismoReal_Usuarios.Core.DTOs;

namespace TurismoReal_Usuarios.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        // GET ALL USERS
        Task<List<UsuarioDTO>> GetUsuarios();

        // GET USER BY ID
        Task<UsuarioDTO> GetUsuario(int id);

        // ADD USER
        Task<int> AddUsuario(UsuarioDTO usuario);

        // UPDATE USER
        Task<int> UpdateUsuario(int id, UsuarioDTO usuario);

        // DELETE USER
        Task<bool> DeleteUsuario(int id);
    }
}
