using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;

namespace Entidades
{
    public partial class Necesidades : EntityObject
    {
        private int v1;
        private string v2;
        private string v3;
        private bool v4;
        private int v5;
        public object Valoracion;

        public int IdNecesidad { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Necesidades(int id, string name, string description)
        {
            this.IdNecesidad = id;
            this.Name = name;
            this.Description = description;
        }

        public Necesidades(int v1, string v2, string v3, bool v4, int v5)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }
    }
}
