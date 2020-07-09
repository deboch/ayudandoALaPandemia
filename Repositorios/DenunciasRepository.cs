using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class DenunciasRepository
    {
        Context Context;
        public DenunciasRepository(Context context)
        {
            this.Context = context;
        }

        public List<Denuncias> traerDenuncias()
        {
            return Context.Denuncias.OrderByDescending(v => v.FechaCreacion).ToList();
        }

        public Denuncias buscarPorId(int id)
        {
            return Context.Denuncias.Where(o => o.IdDenuncia == id).FirstOrDefault();
        }

        public void desestimarDenuncia(Denuncias miDenuncia)
        {
            miDenuncia.Estado = 0;
            Context.SaveChanges();
        }

        public void aceptarDenuncia(Denuncias miDenuncia)
        {
            miDenuncia.Estado = 1;
            Context.SaveChanges();
        }

        public List<MotivoDenuncia> obtenerTodosLosMotivos()
        {
            return Context.MotivoDenuncia.ToList();
        }
    }
}
