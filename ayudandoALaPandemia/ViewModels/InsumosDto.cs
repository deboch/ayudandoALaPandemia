using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class InsumosDto
    {
        [Key]
        public int id { get; set; }

        public int idNecesidad { get; set; }

        public string nombre { get; set; }

        public int cantidad { get; set; }

        public int cantidadDonada { get; set; }
    }
}