using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TurismoReal_Usuarios.Core.DTOs;
using TurismoReal_Usuarios.Core.Interfaces;
using TurismoReal_Usuarios.Infra.Builder;
using TurismoReal_Usuarios.Infra.Context;

namespace TurismoReal_Usuarios.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly OracleContext _context;

        public UsuarioRepository()
        {
            _context = new OracleContext();
        }

        // GET ALL USERS
        public async Task<List<UsuarioDTO>> GetUsuarios()
        {
            try
            {
                _context.OpenConnection();
                OracleCommand cmd = new OracleCommand("sp_obten_usuarios", _context.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("usuarios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();

                List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
                while (reader.Read())
                {
                    UsuarioDTO usuario = UsuarioBuilder.buildUsuarioEntity(reader);
                    usuarios.Add(usuario);
                }
                _context.CloseConnection();
                return usuarios;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // GET USER BY ID
        public async Task<UsuarioDTO> GetUsuario(int id)
        {
            try
            {
                _context.OpenConnection();
                OracleCommand cmd = UsuarioBuilder.ConfigBuscarUsuarioParams(_context.GetConnection());
                cmd.Parameters["usuario_id"].Value = id;

                OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
                UsuarioDTO usuario = null;
                while (reader.Read())
                {
                    usuario = UsuarioBuilder.buildUsuarioEntity(reader);
                }
                reader.Close();
                _context.CloseConnection();
                return usuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // ADD USER
        public async Task<int> AddUsuario(UsuarioDTO usuario)
        {
            int user_id = 0;
            try
            {
                _context.OpenConnection();
                OracleCommand cmd = UsuarioBuilder.ConfigAgregarUsuarioParams(_context.GetConnection());
                UsuarioBuilder.setAgregarUsuarioParams(cmd, usuario);

                await cmd.ExecuteNonQueryAsync();
                _context.CloseConnection();
                user_id = Convert.ToInt32(cmd.Parameters["ok"].Value.ToString());
                return user_id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return user_id;
            }
        }

        // EDIT USER
        public async Task<object> UpdateUsuario(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        // DELETE USER
        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {
                _context.OpenConnection();
                OracleCommand cmd = UsuarioBuilder.ConfigEliminarUsuarioParams(_context.GetConnection());
                cmd.Parameters["usuario_id"].Value = id;
                await cmd.ExecuteNonQueryAsync();
                _context.CloseConnection();

                int removed = int.Parse(cmd.Parameters["removed"].Value.ToString());

                if (removed == 1)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
