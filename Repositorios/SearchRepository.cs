using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using Repositorios.DAL;
using Entidades;
using System.Data.SqlClient;

namespace Repositorios
{
    public class SearchRepository
    {
        Contexts Context;
        public SearchRepository(Contexts context)
        {
            this.Context = context;
        }
        public List<Repositorios.Necesidades> ObtenerNecesidades (int userId, string keyword) {
            try
            {
                return Context.Necesidades.Where(
                    v => v.Nombre.Contains(keyword) && !(v.IdUsuarioCreador == userId)
                ).ToList();
            } catch (System.Data.Entity.Infrastructure.DbUpdateException exception)
            {
                throw exception;
            }
        }
    }
}
