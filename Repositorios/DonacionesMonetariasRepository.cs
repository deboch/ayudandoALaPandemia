using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class DonacionesMonetariasRepository
    {
        Context Context;
        public DonacionesMonetariasRepository(Context context)
        {
            this.Context = context;
        }

        public NecesidadesDonacionesMonetarias obtenerPorNecesidadId(int idNecesidad)
        {
            try
            {
                return Context.NecesidadesDonacionesMonetarias
                    .Where(v => v.IdNecesidad == idNecesidad)
                    .FirstOrDefault();

            }catch(DbException)
            {
                throw;
            }
        }

        public decimal obtenerDinero(int idNecesidadDonacionMonetaria)
        {
            List<DonacionesMonetarias> donaciones = Context.DonacionesMonetarias.Where(v => v.IdNecesidadDonacionMonetaria == idNecesidadDonacionMonetaria).ToList();
            return donaciones.Sum(v => v.Dinero);
        }

        public List<DonacionesMonetarias> ObtenerDonacionesMonetariasUserPorId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
