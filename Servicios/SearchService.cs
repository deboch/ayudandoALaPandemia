using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Servicios
{
    class SearchService
    {
        private List<Necesidad> lista = new List<Necesidad>();
        public List<Necesidad> GetAll()
        {
            Necesidad necesidad_1 = new Necesidad(1, "necesidad 1", "primera necesidad");
            Necesidad necesidad_2 = new Necesidad(2, "necesidad 2", "segunda necesidad");
            lista.Add(necesidad_1);
            lista.Add(necesidad_2);
            return lista;
        }
    }
}
