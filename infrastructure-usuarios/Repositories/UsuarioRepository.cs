using core_usuarios.Entities;
using core_usuarios.Interfaces;
using infrastructure_usuarios.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using core_usuarios.DTOs;

namespace infrastructure_usuarios.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ModelContext _context;

        public UsuarioRepository(ModelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return usuarios;
        }

        public async Task<Usuario> GetUsuario(string rut)
        {
            var usuario = await _context.Usuarios.FromSqlRaw($"exec sp_buscar_usuario_por_rut{rut}").FirstOrDefaultAsync();
            //var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Numrut == rut);
            return usuario;

            //using (OracleConnection con = new OracleConnection(Environment.GetEnvironmentVariable("DB_TURISMO_REAL")))
            //{
            //    using (OracleCommand cmd = con.CreateCommand())
            //    {
            //        try
            //        {

            //        }
            //        catch(Excepction e)
            //        {

            //        }
            //    }
            //}
        }

        public async Task<bool> AddUsuario(UsuarioDTO usuario)
        {
            try
            {
                OracleConnection con = new OracleConnection(Environment.GetEnvironmentVariable("DB_CONNECTION"));
                con.Open();

                OracleCommand cmd = ConfigAgregarUsuarioParams(con);
                setAgregarUsuarioParams(cmd, usuario);

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
                OracleCommand cmd = ConfigEliminarUsuarioParams(con);
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

        public OracleCommand ConfigAgregarUsuarioParams(OracleConnection con)
        {
            OracleCommand cmd = new OracleCommand("sp_agregar_usuario", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("rut_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("dv_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("pnombre_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("snombre_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("apepat_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("apemat_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("fecnac_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("email_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("telmovil_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("telfijo_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("pass_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("genero_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("pais_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("tipo_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("comuna_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("calle_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("numero_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("depto_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("casa_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;

            return cmd;
        }

        public OracleCommand ConfigEliminarUsuarioParams(OracleConnection con)
        {
            OracleCommand cmd = new OracleCommand("sp_eliminar_usuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("rut_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("removed", OracleDbType.Int32).Direction = ParameterDirection.Output;
            return cmd;
        }



        public void setAgregarUsuarioParams(OracleCommand cmd, UsuarioDTO usuario)
        {
            cmd.Parameters["rut_u"].Value = usuario.rut;
            cmd.Parameters["dv_u"].Value = usuario.dv;
            cmd.Parameters["pnombre_u"].Value = usuario.primerNombre;
            cmd.Parameters["snombre_u"].Value = usuario.segundoNombre;
            cmd.Parameters["apepat_u"].Value = usuario.apellidoPaterno;
            cmd.Parameters["apemat_u"].Value = usuario.apellidoMaterno;
            cmd.Parameters["fecnac_u"].Value = usuario.fechaNacimiento.ToString("dd/MM/yyyy");
            cmd.Parameters["email_u"].Value = usuario.correo;
            cmd.Parameters["telmovil_u"].Value = usuario.telefonoMovil;
            cmd.Parameters["telfijo_u"].Value = usuario.telefonoFijo;
            cmd.Parameters["pass_u"].Value = usuario.password;
            cmd.Parameters["genero_u"].Value = usuario.genero;
            cmd.Parameters["pais_u"].Value = usuario.pais;
            cmd.Parameters["tipo_u"].Value = usuario.tipoUsuario;
            cmd.Parameters["comuna_u"].Value = usuario.direccion.comuna;
            cmd.Parameters["calle_u"].Value = usuario.direccion.calle;
            cmd.Parameters["numero_u"].Value = usuario.direccion.numero;
            cmd.Parameters["depto_u"].Value = usuario.direccion.depto;
            cmd.Parameters["casa_u"].Value = usuario.direccion.casa;
        }



    }
}
