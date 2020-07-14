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
            return managerRepository.denunciasRepository.traerDenuncias();
        }

        public Denuncias buscarPorId(int id)
        {
            return managerRepository.denunciasRepository.buscarPorId(id);
        }

        public void desestimarDenuncia(Denuncias miDenuncia)
        {
            Necesidades miNececidad = managerRepository.necesidadesRepository.ObtenerPorId(miDenuncia.IdNecesidad);
            managerRepository.denunciasRepository.desestimarDenuncia(miDenuncia, miNececidad);
        }

        public void aceptarDenuncia(Denuncias miDenuncia)
        {
            Necesidades miNececidad = managerRepository.necesidadesRepository.ObtenerPorId(miDenuncia.IdNecesidad);
            managerRepository.denunciasRepository.aceptarDenuncia(miDenuncia, miNececidad);
        }

        public List<MotivoDenuncia> obtenerTodosLosMotivos()
        {
            return managerRepository.denunciasRepository.obtenerTodosLosMotivos();
        }
    }
}
