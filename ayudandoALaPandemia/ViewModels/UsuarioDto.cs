using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class UsuarioDto
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellido { get; set; }
        
        [Range(typeof(DateTime), "1/1/2002", "1/1/2199", ErrorMessage = "Debe ser mayor de 18")]
        public DateTime fechaNacimiento { get; set; }
        public string username { get; set; }

        [Required]
        public string email { get; set; }
        
        [Required]
        public string password { get; set; }

        [Required]
        public string foto { get; set; }
        public int tipoUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
        public bool activo { get; set; }

        public string NombreSignificativoImagen
        {
            get
            {
                return string.Format("{0}{1}", this.apellido ?? "Apellido", this.nombre ?? "Nombre");
            }
        }

    }
}