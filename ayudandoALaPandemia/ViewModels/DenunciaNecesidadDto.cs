using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class DenunciaNecesidadDto
    {
        [Key]
        public int id { get; set; }
        public int usuarioId { get; set; }
        public int necesidadId { get; set; }
        public int motivoDenunciaId { get; set; }

        [Required(ErrorMessage = "Ingrese un comentario")]
        public string comentarios { get; set; }
        public int estado { get; set; }
    }
}