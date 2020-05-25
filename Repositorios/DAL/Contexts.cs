using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repositorios.DAL
{
    public class Contexts : DbContext
    {
        public Contexts() : base("name=Entities1") { }
        
        public virtual DbSet<Necesidades> Necesidades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    }

}
