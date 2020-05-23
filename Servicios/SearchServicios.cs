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
        ManagerRepository managerRepository = new ManagerRepository();
        public List<Repositorios.Necesidades> ObtenerNecesidades()
        {
            return managerRepository.searchRepository.ObtenerNecesidades();
        }
    }
}
