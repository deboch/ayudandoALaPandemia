using ayudandoALaPandemia.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class NecesidadDto
    {
        public NecesidadDto()
        {
            this.insumos = new List<InsumosDto>();
            this.referencias = new List<ReferenciaDto>(){
                new ReferenciaDto(),
                new ReferenciaDto(),
            };
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Elija un nombre")]
        [StringLength(200)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Agregue una descripcion")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Debe agregar una fecha")]
        [DateValidator(ErrorMessage = "La fecha debe ser mayor a la actual")]
        public DateTime fechaFin { get; set; }

        [Required(ErrorMessage = "Agregue un telefono de contacto")]
        public string telefono { get; set; }

        [Required]
        public string tipoDonacion { get; set; }

        [Required(ErrorMessage = "Debe agregar una foto")]
        public string foto { get; set; }
        
        public int idMonetaria { get; set; }

        public decimal dinero { get; set; }

        public string cbu { get; set; }
        public List<InsumosDto> insumos { get; set; }

        public List<ReferenciaDto> referencias { get; set; }

        public int idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public dynamic valoracion { get; set; }
        public decimal estrellas { get; set; }
        public string NombreSignificativoImagen

        {
            get
            {
                return string.Format("{0}{1}", this.nombre.Replace(" ", "_") ?? "Nombre", this.tipoDonacion ?? "Dombre");
            }
        }
    }
}
