using System;
using System.Collections.Generic;
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

        public Repositorios.Usuarios obtenerUsuario (string email)
        {
            var user = Context.Usuarios
                                .Where(b => (string)b.Email == (string)email)
                                .FirstOrDefault();                            
            return user;
        }
    }
}
