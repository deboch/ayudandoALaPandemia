using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [MetadataType(typeof(UsuariosMetadata))]
    partial class Usuarios
    {
        private sealed class UsuariosMetadata
        {
            [EmailAddress(ErrorMessage = "Ingrese un mail válido")]
            public string Email { get; set; }
            
            [Required(ErrorMessage = "Por favor ingrese su clave")]
            [Range(8, 30, ErrorMessage = "Su clave debe ser mayor a 8 y menor a 30")]
            public string Password { get; set; }
        }
    }
}
