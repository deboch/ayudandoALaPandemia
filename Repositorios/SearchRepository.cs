using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using Repositorios.DAL;

namespace Repositorios
{
    public class SearchRepository
    {
        Contexts Context;
        public SearchRepository(Contexts context)
        {
            this.Context = context;
        }
        public List<Repositorios.Necesidades> ObtenerNecesidades () {
            return Context.Necesidades.ToList();
        }
    }
}
