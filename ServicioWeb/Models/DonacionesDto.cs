using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Models
{
    public class DonacionesDto
    {
        public DonacionesDto()
        {
            this.listaInsumos = new List<InsumosDto>();
        }

        public int id { get; set; }
        public DateTime fechaNecesidad { get; set; }
        public DateTime fechaDeDonación { get; set; }
        public string nombre { get; set; }
        public int tipoDonacion { get; set; }
        public int estado { get; set; }
        public decimal totalRecaudado { get; set; }
        public decimal totalDonacion { get; set; }
        public int idNecesidad { get; set; }

        public List<InsumosDto> listaInsumos { get; set; }
    }
}