using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class DonacionMonetariaDto
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }
        public int IdNecesidadDonacionMonetaria { get; set; }

        [Required(ErrorMessage = "Agregue una suma de dinero")]
        public decimal dinero { get; set; }

        [Required(ErrorMessage = "Debe agregar un comprobante")]
        public string comprobante { get; set; }

        public decimal totalRestante { get; set; }
        public decimal totalDeDinero { get; set; }
    }
}