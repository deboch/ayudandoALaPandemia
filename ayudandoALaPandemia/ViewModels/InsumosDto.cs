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

        [Required]
        public string nombre { get; set; }

        [Required]
        public int cantidad { get; set; }
    }
}