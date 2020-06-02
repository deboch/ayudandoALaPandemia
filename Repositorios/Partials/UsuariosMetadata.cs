using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(8, MinimumLength = 1,ErrorMessage = "japiiiiiiish basura, poné la clave bien.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "japiiiiiiish basura, validá la clave bien", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
