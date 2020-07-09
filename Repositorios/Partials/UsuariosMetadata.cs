using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class UsuariosMetadata
    {


        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La clave es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Minimo 1 máximo 8")]
        public string Password { get; set; }

        /*[Required(ErrorMessage = "Confirmar la clave, por favor")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Las claves no coinciden")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }*/

        [Required(ErrorMessage = "La fecha es requerida")]
        /*[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]*/
        public System.DateTime FechaNacimiento { get; set; }


    }

}
