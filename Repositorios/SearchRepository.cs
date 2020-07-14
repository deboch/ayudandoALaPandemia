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
        public List<Necesidades> ObtenerNecesidades(int userId, string keyword)
        {
            try
            {
                return Context.Necesidades.Where(
                    v => ((v.Nombre.Contains(keyword) || v.Usuarios.Nombre.Contains(keyword)) && !(v.IdUsuarioCreador == userId) && v.Estado != 1)
                ).OrderByDescending(v => v.FechaFin).ThenByDescending(v => v.Valoracion).ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException exception)
            {
                throw exception;
            }
        }
    }
}
