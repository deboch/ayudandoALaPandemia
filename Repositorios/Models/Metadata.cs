using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{

    public class UsuariosMetadata
    {
        [Required(ErrorMessage = "Please type a email")]
        [Display(Name = "Personal Email")]
        [Column(TypeName = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please type a password")]
        [Display(Name = "Personal Password")]
        [Column(TypeName = "password")]
        public string Password { get; set; }
     }
}
