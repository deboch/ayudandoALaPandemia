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

        public Denuncias buscarPorId(int id)
        {
            return managerRepository.denunciasRepository.buscarPorId(id);
        }

        public void desestimarDenuncia(Denuncias miDenuncia)
        {
            managerRepository.denunciasRepository.desestimarDenuncia(miDenuncia);
        }

        public void aceptarDenuncia(Denuncias miDenuncia)
        {
            managerRepository.denunciasRepository.aceptarDenuncia(miDenuncia);
        }
    }
}
