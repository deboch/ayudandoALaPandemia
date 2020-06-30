using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;

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
            }
            catch (DbUpdateException)
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

        public List<Necesidades> obtenerMasValoradas()
        {
            return Context.Necesidades.OrderByDescending(v => v.Valoracion).ToList();
        }

        public Necesidades ObtenerPorId(int id)
        {
            return Context.Necesidades.Where(v => v.IdNecesidad == id).FirstOrDefault();
        }

        public List<Necesidades> ObtenerPorUserId(int id)
        {
            try
            {
                return Context.Necesidades
                    .Where(b => (int)b.IdUsuarioCreador == (int)id)
                    .ToList();

            }
            catch (EntityException)
            {
                throw new EntityException();
            }
        }

        public List<Necesidades> ObtenerNecesidadesSegunActivacion(bool isActive, int userId)
        {
            int estado = isActive ? 1 : 0;
            return Context.Necesidades.Where(v => v.Estado == estado && v.IdUsuarioCreador == userId).ToList();
        }

        public List<Necesidades> ObtenerTodasMenosPorUserId(int userId)
        {
            return Context.Necesidades.Where(v => (int)v.IdUsuarioCreador != (int)userId).ToList();
        }

        public DonacionesInsumos donacionInsumo(DonacionesInsumos donacionesInsumos)
        {
            int id = donacionesInsumos.IdNecesidadDonacionInsumo;
            NecesidadesDonacionesInsumos necesidadInsumo = Context.NecesidadesDonacionesInsumos.Find(id);
            necesidadInsumo.DonacionesInsumos.Add(donacionesInsumos);
            Context.SaveChanges();
            return donacionesInsumos;
        }

        public DonacionesMonetarias donacionMonetaria(DonacionesMonetarias donacionesMonetarias)
        {
            int id = donacionesMonetarias.IdNecesidadDonacionMonetaria;
            NecesidadesDonacionesMonetarias necesidadMonetaria = Context.NecesidadesDonacionesMonetarias.Find(id);
            necesidadMonetaria.DonacionesMonetarias.Add(donacionesMonetarias);
            Context.SaveChanges();
            return donacionesMonetarias;
        }

        public List<NecesidadesValoraciones> obtenerTotalValoraciones(int idNecesidad)
        {
            try
            {
                List<NecesidadesValoraciones> valoraciones = Context.NecesidadesValoraciones.Where(v => v.IdNecesidad == idNecesidad).ToList();
                return valoraciones;
            }
            catch (DbUpdateException)
            {
                new DbUpdateException("falló en obtener valoraciones");
                throw;
            }
        }

        public bool Valorar(int like, int userId, int idNecesidad)
        {
            try
            {
                NecesidadesValoraciones valoracion = new NecesidadesValoraciones();
                NecesidadesValoraciones miValoracion = Context.NecesidadesValoraciones.Where(v => v.IdUsuario == userId && v.IdNecesidad == idNecesidad).FirstOrDefault();
                if (miValoracion != null)
                {
                    miValoracion.Valoracion = like == 1;
                    Context.SaveChanges();
                    return like == 1;
                }
                valoracion.IdUsuario = userId;
                valoracion.IdNecesidad = idNecesidad;
                valoracion.Valoracion = like == 1;
                Context.NecesidadesValoraciones.Add(valoracion);
                Context.SaveChanges();
                return like == 1;
            }
            catch (DbUpdateException)
            {
                new DbUpdateException("no se pudo agregar la valoracion");
                throw;
            }
        }

        public int CalcularPorcentaje(int idNecesidad)
        {
            Necesidades necesidad = Context.Necesidades.Find(idNecesidad);
            int totalLike = Context.NecesidadesValoraciones.Where(v => v.Valoracion == true).ToList().Count();
            int total = Context.NecesidadesValoraciones.Where(v => v.IdNecesidad == idNecesidad).ToList().Count();
            int porcentaje = (totalLike / total) * 100;
            necesidad.Valoracion = porcentaje;
            Context.SaveChanges();
            return porcentaje;
        }
        public int CrearDenuncia(Denuncias denuncia)
        {
            Context.Denuncias.Add(denuncia);
            Context.SaveChanges();
            return denuncia.IdDenuncia;
        }
    }
}
