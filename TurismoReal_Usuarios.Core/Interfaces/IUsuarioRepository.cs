using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Usuarios.Core.DTOs;
using TurismoReal_Usuarios.Core.Messages;

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
        Task<int> DeleteUsuario(int id);

        // UPDATE PASSWORD
        Task<int> UpdatePassword(int id, PasswordPayload password);
    }
}
