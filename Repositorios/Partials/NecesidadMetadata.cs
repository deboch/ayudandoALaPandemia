using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Partials
{
    public class NecesidadMetadata
    {
        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripcion requerida")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Fecha de fin requerida")]
        public System.DateTime FechaFin { get; set; }
        [Required(ErrorMessage = "Telefono requerido")]
        public string TelefonoContacto { get; set; }
        [Required(ErrorMessage = "Tipo de donacion requerido.")]
        public int TipoDonacion { get; set; }
        [Required(ErrorMessage = "Foto requerida.")]
        public string Foto { get; set; }
        [Required(ErrorMessage = "Nombre de referencia requerido.")]
        public string Referencia1Nombre { get; set; }
        [Required(ErrorMessage = "Telefono de referencia requerido.")]
        public string Referencia1Telefono { get; set; }
        [Required(ErrorMessage = "Nombre de referencia requerido.")]
        public string Referencia2Nombre { get; set; }
        [Required(ErrorMessage = "Telefono de referencia requerido.")]
        public string Referencia2Telefono { get; set; }
    }
}
