using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
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

        public int Borrar(int id)
        {
            try
            {
                Necesidades necesidad = Context.Necesidades.Find(id);
                int IdNecesidad = necesidad.IdNecesidad;
                foreach (var p in necesidad.NecesidadesDonacionesInsumos.Where(s => s.IdNecesidad == IdNecesidad).ToList())
                {
                    Context.NecesidadesDonacionesInsumos.Remove(p);
                }
                foreach (var p in necesidad.NecesidadesReferencias.Where(s => s.IdNecesidad == IdNecesidad).ToList())
                {
                    Context.NecesidadesReferencias.Remove(p);
                }
                foreach (var p in necesidad.NecesidadesDonacionesMonetarias.Where(s => s.IdNecesidad == IdNecesidad).ToList())
                {
                    Context.NecesidadesDonacionesMonetarias.Remove(p);
                }
                foreach (var p in necesidad.NecesidadesValoraciones.Where(s => s.IdNecesidad == IdNecesidad).ToList())
                {
                    Context.NecesidadesValoraciones.Remove(p);
                }
                foreach (var p in necesidad.Denuncias.Where(s => s.IdNecesidad == IdNecesidad).ToList())
                {
                    Context.Denuncias.Remove(p);
                }
                Context.Necesidades.Remove(necesidad);
                Context.SaveChanges();
                return IdNecesidad;
            } catch (DbUpdateException)
            {
                new DbUpdateException("no se pudo borrar la entidad");
                throw;
            }
        }

        public int Crear(Necesidades necesidad)
        {
            Context.Necesidades.Add(necesidad);
            Context.SaveChanges();
            return necesidad.IdNecesidad;
        }

        public Necesidades Modificar(Necesidades necesidadModificada)
        {
            Necesidades necesidadActual = Context.Necesidades.Find(necesidadModificada.IdNecesidad);
            necesidadActual = necesidadModificada;
            Context.Necesidades.Add(necesidadActual);
            Context.SaveChanges();
            return necesidadModificada;
        }

        public List<Necesidades> ObtenerTodos()
        {
            return Context.Necesidades.ToList();
        }

        public List<Repositorios.Necesidades> obtenerMasValoradas ()
        {
            return Context.Necesidades.ToList();
        }

        public Necesidades ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Necesidades> ObtenerPorUserId(int id)
        {
            try
            {
                return Context.Necesidades
                    .Where(b => (int)b.IdUsuarioCreador == (int)id)
                    .ToList();

            } catch (EntityException)
            {

                throw new EntityException();
            }
        }
    }
}
