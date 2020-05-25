using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios.DAL;

namespace Repositorios
{
    public class NecesidadesRepository
    {
        Contexts Context;
        public NecesidadesRepository(Contexts context)
        {
            this.Context = context;
        }

        public List<Repositorios.Necesidades> obtenerMasValoradas ()
        {
            return Context.Necesidades.ToList();
        }
    }
}
