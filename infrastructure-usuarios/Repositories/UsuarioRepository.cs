using core_usuarios.DTOs;
using core_usuarios.Interfaces;
using infrastructure_usuarios.Builder;
using infrastructure_usuarios.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace infrastructure_usuarios.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ModelContext _context;

        public UsuarioRepository(ModelContext context)
        {
            _context = context;
        }
        public async Task<List<UsuarioDTO>> GetUsuarios()
        {
            try
            {
                OracleConnection con = new OracleConnection(Environment.GetEnvironmentVariable("DB_CONNECTION"));
                con.Open();

                OracleCommand cmd = new OracleCommand("sp_obten_usuarios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("usuarios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
                con.Close();
                
                List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
                while (reader.Read())
                {
                    UsuarioDTO usuario = UsuarioBuilder.buildUsuarioEntity(reader);
                    usuarios.Add(usuario);
                }
                return usuarios;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<UsuarioDTO> GetUsuario(string rut)
        {
            try
            {
                OracleConnection con = new OracleConnection(Environment.GetEnvironmentVariable("DB_CONNECTION"));
                con.Open();

                OracleCommand cmd = UsuarioBuilder.ConfigBuscarUsuarioParams(con);
                cmd.Parameters["rut"].Value = rut;

                OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
                UsuarioDTO usuario = null;
                while (reader.Read())
                {
                    usuario = UsuarioBuilder.buildUsuarioEntity(reader);
                }
                reader.Close();
                con.Close();
                return usuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> AddUsuario(UsuarioDTO usuario)
        {
            try
            {
                OracleConnection con = new OracleConnection(Environment.GetEnvironmentVariable("DB_CONNECTION"));
                con.Open();

                OracleCommand cmd = UsuarioBuilder.ConfigAgregarUsuarioParams(con);
                UsuarioBuilder.setAgregarUsuarioParams(cmd, usuario);

                await cmd.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public async Task<bool> DeleteUsuario(string rut)
        {
            try
            {
                OracleConnection con = new OracleConnection(Environment.GetEnvironmentVariable("DB_CONNECTION"));
                con.Open();
                OracleCommand cmd = UsuarioBuilder.ConfigEliminarUsuarioParams(con);
                cmd.Parameters["rut_u"].Value = rut;
                await cmd.ExecuteNonQueryAsync();
                con.Close();

                int removed = int.Parse(cmd.Parameters["removed"].Value.ToString());

                if(removed == 1)
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
