using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class checkboxDto
    {
        [Key]
        public int id;
        public bool activo { get; set; }
    }
}