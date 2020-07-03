using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class ReferenciaDto
    {
        [Key]
        public int id { get; set; }

        public string nombre { get; set; }

        public string telefono { get; set; }
    }
}