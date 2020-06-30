using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DenunciasServicios
    {
        ManagerRepository managerRepository = new ManagerRepository();

        public List<Denuncias> listaDenuncias()
        {
            return managerRepository.denunciasRepository.traerDenuncias().ToList();
        }
    }
}
