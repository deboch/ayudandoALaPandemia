using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Repositorios
{
    public class UsuarioRepository
    {
        Context Context;
        public UsuarioRepository(Context context)
        {
            this.Context = context;
        }

        public Usuarios obtenerUsuario(string email)
        {
            try
            {
                var user = Context.Usuarios
                    .Where(b => (string)b.Email == (string)email)
                    .FirstOrDefault();
                return user;

            } catch(DbEntityValidationException e)
            {
                foreach(var eve in e.EntityValidationErrors)
                {
                     foreach(var p in eve.ValidationErrors)
                    {
                        Console.WriteLine(p.GetType().Name);
                        Console.WriteLine(p.ErrorMessage);
                        throw;
                    }
                }
            }
            return null;
        }
    }
}
