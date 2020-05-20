using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using Repositorios.DAL;

namespace Repositorios
{
    public class SearchRepository
    {
        private NecesidadesContext context;

        public SearchRepository(NecesidadesContext context)
        {
            this.context = context;
        }

        public List<Necesidades> ObtenerNecesidades () {
            return context.necesidades.ToList();
        }
    }
}
