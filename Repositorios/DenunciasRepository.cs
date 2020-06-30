using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class DenunciasRepository
    {
        Context Context;
        public DenunciasRepository(Context context)
        {
            this.Context = context;
        }

        public List<Denuncias> traerDenuncias()
        {
            return Context.Denuncias.ToList();
        }
    }
}
