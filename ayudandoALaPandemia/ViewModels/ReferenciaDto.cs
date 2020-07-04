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

        [Required(ErrorMessage = "Agregue un nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Agregue un telefono")]
        public string telefono { get; set; }
    }
}