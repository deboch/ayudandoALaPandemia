﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.ViewModels
{
    public class NecesidadDto
    {
        public NecesidadDto()
        {
            this.insumos = new List<InsumosDto>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string nombre { get; set; }

        [Required]
        public string descripcion { get; set; }
        public DateTime fechaFin { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
        public string tipoDonacion { get; set; }
        public string foto { get; set; }
        public decimal dinero { get; set; }
        public string cbu { get; set; }
        public List<InsumosDto> insumos { get; set; }
        public string referencia1Nombre { get; set; }
        public string referencia2Nombre { get; set; }
        public string referencia1Telefono { get; set; }
        public string referencia2Telefono { get; set; }

    }
}