using Repositorios;
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
        public MotivoDenuncia MotivoDenuncia { get; set; }
        public string Comentarios { get; set; }
        public int Estado { get; set; }
    }
}