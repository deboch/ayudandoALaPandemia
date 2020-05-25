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
            return Context.Usuarios
                .Where(m => m.Email == email)
                .SingleOrDefault();
        }
    }
}
