using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Servicios
{
    public class DonacionesInsumosServicios
    {
        ManagerRepository managerRepository = new ManagerRepository();

        public List<NecesidadesDonacionesInsumos> ObtenerPorNecesidadId(int idNecesidad)
        {
            return managerRepository.donacionesInsumosRepository.ObtenerPorNecesidadId(idNecesidad);
        }

        public object obtenerCantidadesRestantes(List<NecesidadesDonacionesInsumos> donacion)
        {
            Dictionary<string, int> cantidades = new Dictionary<string, int>();

            donacion.ToList().ForEach(p =>
            {
                int dInsumos = managerRepository.donacionesInsumosRepository.obtenerTotalDeDonaciones(p.IdNecesidadDonacionInsumo);
                int resto = p.Cantidad - dInsumos;
                cantidades.Add(p.Nombre, resto);
            });

            return cantidades;
        }
    }
}
