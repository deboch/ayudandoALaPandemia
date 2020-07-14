using System.Collections.Generic;
using System.Linq;
using Repositorios;


namespace Servicios
{
    public class HomeServicios
    {
        ManagerRepository managerRepository = new ManagerRepository();
        public List<Necesidades> GetMasValorados()
        {
            var listaOrdenada = managerRepository.necesidadesRepository
                .obtenerMasValoradas()
                .Where(o => o.Estado != 1 && o.Estado != 3)
                .OrderByDescending(x => x.Valoracion)
                .Take(5)
                .ToList();

            return listaOrdenada;
        }
    }
}
