using System;
using System.Data.Entity;

namespace Repositorios.DAL
{
    public class Contexts : DbContext
    {
        public Contexts() : base("name=Entities") { }
        public DbSet<Necesidades> Necesidades { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }

}
