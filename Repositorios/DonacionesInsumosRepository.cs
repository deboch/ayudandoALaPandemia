using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class DonacionesInsumosRepository
    {
        Context Context;
        public DonacionesInsumosRepository(Context context)
        {
            this.Context = context;
        }

        public List<NecesidadesDonacionesInsumos> ObtenerPorNecesidadId(int idNecesidad)
        {
            try
            {
                return Context.NecesidadesDonacionesInsumos
                    .Where(v => v.IdNecesidad == idNecesidad)
                    .ToList();
            }
            catch (DbException)
            {
                throw;
            }
        }

        public int obtenerTotalDeDonaciones(int idNecesidadDonacionInsumo)
        {
            try
            {
                List<DonacionesInsumos> donaciones = Context.DonacionesInsumos.Where(v => v.IdNecesidadDonacionInsumo == idNecesidadDonacionInsumo).ToList();
                return donaciones.Sum(v => v.Cantidad);
            }
            catch(DbException)
            {
                throw;
            }
        }

        public DonacionesInsumos ObtenerTotales(int idNecesidadDonacionInsumo)
        {
            throw new NotImplementedException();
        }

        public List<DonacionesInsumos> ObtenerDonacionesInsumosPorUserId(int userId)
        {
            return Context.DonacionesInsumos.Where(v => v.IdUsuario == userId).ToList();
        }

    }
}
