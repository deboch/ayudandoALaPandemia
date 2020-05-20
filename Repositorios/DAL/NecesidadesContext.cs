using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repositorios.DAL
{
    public class NecesidadesContext : DbContext
    {
        public DbSet<Necesidades> necesidades { get; set; }
    }

}
