using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Repositorios;
using Repositorios.DAL;

namespace Servicios
{
    public class SearchServicios
    {
        private NecesidadesContext context;

        private SearchRepository searchRepository = new SearchRepository(context);

        public List<Necesidades> ObtenerNecesidades()
        {
            return searchRepository.ObtenerNecesidades();
        }
    }
}
