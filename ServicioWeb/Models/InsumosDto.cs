using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Models
{
    public class InsumosDto
    {
        public int id { get; set; }
        public int idNecesidad { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
    }
}