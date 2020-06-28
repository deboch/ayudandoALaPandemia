using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class SearchRepository
    {
        Context Context;
        public SearchRepository(Context context)
        {
            this.Context = context;
        }
        public List<Repositorios.Necesidades> ObtenerNecesidades(int userId, string keyword)
        {
            try
            {
                return Context.Necesidades.Where(
                    v => v.Nombre.Contains(keyword) && !(v.IdUsuarioCreador == userId)
                ).OrderByDescending(v => v.FechaFin).ThenByDescending(v => v.Valoracion).ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException exception)
            {
                throw exception;
            }
        }
    }
}
