using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
