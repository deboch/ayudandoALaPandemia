using System.Collections.Generic;
using Repositorios;

namespace Servicios
{
    public class SearchServicios
    {
        ManagerRepository managerRepository = new ManagerRepository();
        public List<Repositorios.Necesidades> ObtenerNecesidades(int userId, string keyword)
        {
            return managerRepository.searchRepository.ObtenerNecesidades(userId, keyword);
        }
    }
}
