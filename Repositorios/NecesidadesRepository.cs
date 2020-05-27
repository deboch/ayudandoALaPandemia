using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Repositorios
{
    public class NecesidadesRepository
    {
        Context Context;
        public NecesidadesRepository(Context context)
        {
            this.Context = context;
        }

        public List<Repositorios.Necesidades> obtenerMasValoradas ()
        {
            return Context.Necesidades.ToList();
        }
    }
}
