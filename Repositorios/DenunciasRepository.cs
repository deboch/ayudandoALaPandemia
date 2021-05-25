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
            return Context.Denuncias.Where(o => o.Estado == 3).ToList();
        }

        public Denuncias buscarPorId(int id)
        {
            return Context.Denuncias.Where(o => o.IdDenuncia == id).FirstOrDefault();
        }

        public void desestimarDenuncia(Denuncias miDenuncia, Necesidades miNecesidad)
        {
            miDenuncia.Estado = 0;
            miNecesidad.Estado = 0;
            Context.SaveChanges();
        }

        public void aceptarDenuncia(Denuncias miDenuncia, Necesidades miNecesidad)
        {
            miDenuncia.Estado = 1;
            miNecesidad.Estado = 1;
            Context.SaveChanges();
        }

        public List<MotivoDenuncia> obtenerTodosLosMotivos()
        {
            return Context.MotivoDenuncia.ToList();
        }
    }
}
