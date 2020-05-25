using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;


namespace Servicios
{
    public class HomeServicios
    {
        ManagerRepository managerRepository = new ManagerRepository();
        public List<Necesidades> GetMasValorados()
        {
            /*List<Necesidades> necesidades = new List<Necesidades>();
            List<Necesidades> masValoradas = new List<Necesidades>();

            Necesidades necesidad1 = new Necesidades(1, "uno", "", true, 5);
            Necesidades necesidad2 = new Necesidades(2, "ds", "", true, 4);
            Necesidades necesidad3 = new Necesidades(3, "fdfh", "", true, 2);
            Necesidades necesidad4 = new Necesidades(4, "fghfg", "", true, 5);
            Necesidades necesidad5 = new Necesidades(5, "ufhghno", "", true, 4);
            Necesidades necesidad6 = new Necesidades(6, "fgfj", "", true, 2);

            necesidades.Add(necesidad1);
            necesidades.Add(necesidad2);
            necesidades.Add(necesidad3);
            necesidades.Add(necesidad4);
            necesidades.Add(necesidad5);
            necesidades.Add(necesidad6);*/

            var listaOrdenada = managerRepository.necesidadesRepository
                .obtenerMasValoradas()
                .OrderByDescending(x => x.Valoracion)
                .Take(3)
                .ToList();

            return listaOrdenada;
        }
    }
}
