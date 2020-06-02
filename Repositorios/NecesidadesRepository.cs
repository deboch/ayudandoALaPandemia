using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Repositorios
{
    public class NecesidadesRepository : ICrud<Necesidades>
    {
        Context Context;
        public NecesidadesRepository(Context context)
        {
            this.Context = context;
        }

        public int Borrar(Necesidades obj)
        {
            throw new NotImplementedException();
        }

        public int Crear(Necesidades necesidad)
        {
            Context.Necesidades.Add(necesidad);
            Context.SaveChanges();
            return necesidad.IdNecesidad;
        }

        public Necesidades Modificar(Necesidades obj)
        {
            throw new NotImplementedException();
        }

        public List<Necesidades> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public List<Repositorios.Necesidades> obtenerMasValoradas ()
        {
            return Context.Necesidades.ToList();
        }

        public Necesidades ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
