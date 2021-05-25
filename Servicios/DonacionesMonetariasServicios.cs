using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Servicios
{
    public class DonacionesMonetariasServicios : ICrud<NecesidadesDonacionesMonetarias>
    {
        ManagerRepository managerRepository = new ManagerRepository();

        public int Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public int Crear(NecesidadesDonacionesMonetarias obj)
        {
            throw new NotImplementedException();
        }

        public NecesidadesDonacionesMonetarias Modificar(NecesidadesDonacionesMonetarias obj)
        {
            throw new NotImplementedException();
        }

        public NecesidadesDonacionesMonetarias ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public NecesidadesDonacionesMonetarias ObtenerPorNecesidadId(int necesidadId)
        {
            return managerRepository.donacionesMonetariasRepository.obtenerPorNecesidadId(necesidadId);
        }

        public decimal ObtenerTodasLasDonaciones(NecesidadesDonacionesMonetarias donacion)
        {
            decimal totalCant = managerRepository.donacionesMonetariasRepository.obtenerDinero(donacion.IdNecesidadDonacionMonetaria);
            return totalCant;
        }

        public List<NecesidadesDonacionesMonetarias> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
