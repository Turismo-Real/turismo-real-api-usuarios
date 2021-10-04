using core_usuarios.Entities;
using core_usuarios.Interfaces;
using infrastructure_usuarios.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

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
    }
}
