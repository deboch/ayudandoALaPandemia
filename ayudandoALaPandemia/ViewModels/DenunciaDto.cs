using Repositorios.Partials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class DenunciaDto
    {
        [Key]
        public int Id { get; set; }
        public L MotivoDenuncia { get; set; }
        public string Comentarios { get; set; }
        public int Estado { get; set; }
    }
}