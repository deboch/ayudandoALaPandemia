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
        [Required]
        [EmailAddress(ErrorMessage = "Ingrese un mail válido")]
        public string Email { get; set; }

        /*[Required]
        [StringLength(50, MinimumLength = 1,ErrorMessage = "japiiiiiiish basura, poné la clave bien.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(50, ErrorMessage = "japiiiiiiish basura, validá la clave bien", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public System.DateTime FechaNacimiento { get; set; }*/
          

    }

}
