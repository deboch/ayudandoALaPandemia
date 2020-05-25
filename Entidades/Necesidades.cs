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
        public int IdNecesidad { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Necesidades(int id, string name, string description)
        {
            this.IdNecesidad = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
