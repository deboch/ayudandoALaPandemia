using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios.DAL;

namespace Repositorios
{
    public class UsuarioRepository
    {
        Contexts Context;
        public UsuarioRepository(Contexts context)
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
