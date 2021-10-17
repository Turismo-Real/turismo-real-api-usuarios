using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using TurismoReal_Usuarios.Core.DTOs;

namespace TurismoReal_Usuarios.Infra.Builder
{
    public class UsuarioBuilder
    {
        public static OracleCommand ConfigUsuarioParams(OracleConnection con, string procedureName)
        {
            OracleCommand cmd = new OracleCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;
            cmd.Parameters.Add("pasaporte_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
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

        public static OracleCommand ConfigEliminarUsuarioParams(OracleConnection con)
        {
            OracleCommand cmd = new OracleCommand("sp_eliminar_usuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("usuario_id", OracleDbType.Int32).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("removed", OracleDbType.Int32).Direction = ParameterDirection.Output;
            return cmd;
        }

        public static OracleCommand ConfigBuscarUsuarioParams(OracleConnection con)
        {
            OracleCommand cmd = new OracleCommand("sp_usuario_por_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("usuario_id", OracleDbType.Int32).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("cur_user", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            return cmd;
        }

        public static void setUsuarioParams(OracleCommand cmd, UsuarioDTO usuario)
        {
            cmd.Parameters["pasaporte_u"].Value = usuario.pasaporte;
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
            cmd.Parameters["genero_u"].Value = usuario.genero;
            cmd.Parameters["pais_u"].Value = usuario.pais;
            cmd.Parameters["tipo_u"].Value = usuario.tipoUsuario;
            cmd.Parameters["comuna_u"].Value = usuario.direccion.comuna;
            cmd.Parameters["calle_u"].Value = usuario.direccion.calle;
            cmd.Parameters["numero_u"].Value = usuario.direccion.numero;
            cmd.Parameters["depto_u"].Value = usuario.direccion.depto;
            cmd.Parameters["casa_u"].Value = usuario.direccion.casa;
        }

        public static UsuarioDTO buildUsuarioEntity(OracleDataReader reader)
        {
            UsuarioDTO user = new UsuarioDTO();
            user.id = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("id_usuario")).ToString());
            user.pasaporte = reader.GetValue(reader.GetOrdinal("pasaporte")).ToString();
            user.rut = reader.GetValue(reader.GetOrdinal("numrut")).ToString();
            user.dv = reader.GetValue(reader.GetOrdinal("dvrut")).ToString();
            user.primerNombre = reader.GetValue(reader.GetOrdinal("pnombre")).ToString();
            user.segundoNombre = reader.GetValue(reader.GetOrdinal("snombre")).ToString();
            user.apellidoPaterno = reader.GetValue(reader.GetOrdinal("apepat")).ToString();
            user.apellidoMaterno = reader.GetValue(reader.GetOrdinal("apemat")).ToString();
            user.fechaNacimiento = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("fec_nac")).ToString());
            user.correo = reader.GetValue(reader.GetOrdinal("correo")).ToString();
            user.telefonoMovil = reader.GetValue(reader.GetOrdinal("telefono_movil")).ToString();
            user.telefonoFijo = reader.GetValue(reader.GetOrdinal("telefono_fijo")).ToString();
            user.genero = reader.GetValue(reader.GetOrdinal("genero")).ToString();
            user.pais = reader.GetValue(reader.GetOrdinal("pais")).ToString();
            user.tipoUsuario = reader.GetValue(reader.GetOrdinal("tipo")).ToString();

            DireccionDTO user_direction = new DireccionDTO();
            user_direction.region = reader.GetValue(reader.GetOrdinal("region")).ToString();
            user_direction.comuna = reader.GetValue(reader.GetOrdinal("comuna")).ToString();
            user_direction.calle = reader.GetValue(reader.GetOrdinal("calle")).ToString();
            user_direction.numero = reader.GetValue(reader.GetOrdinal("numero")).ToString();
            user_direction.depto = reader.GetValue(reader.GetOrdinal("depto")).ToString();
            user_direction.casa = reader.GetValue(reader.GetOrdinal("casa")).ToString();
            user.direccion = user_direction;
            user.direccion = user_direction;
            return user;
        }
    }
}
