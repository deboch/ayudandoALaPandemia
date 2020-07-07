using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Models
{
    public class MonetariaDto
    {
        public int id { get; set; }
        public int idNecesidad { get; set; }
        public int idUsuario { get; set; }
        public decimal dinero { get; set; }

        public DateTime fechaCreacion { get; set; }

        public MonetariaDto()
        {

        }
        public MonetariaDto(DonacionesMonetarias monetaria)
        {
            this.id = monetaria.IdDonacionMonetaria;
            this.idNecesidad = monetaria.IdNecesidadDonacionMonetaria;
            this.idUsuario = monetaria.IdUsuario;
            this.dinero = monetaria.Dinero;
            this.fechaCreacion = monetaria.FechaCreacion;
        }
        public DonacionesMonetarias MapearEF()
        {
            DonacionesMonetarias p = new DonacionesMonetarias();
            p.IdDonacionMonetaria = this.id;
            p.IdNecesidadDonacionMonetaria = this.idNecesidad;
            p.IdUsuario = this.idUsuario;
            p.Dinero = this.dinero;
            p.FechaCreacion = this.fechaCreacion;
            return p;
        }
        public List<DonacionesMonetarias> MapearListaDto(List<MonetariaDto> monetariaDto)
        {
            List<DonacionesMonetarias> monetariaEF = new List<DonacionesMonetarias>();

            foreach (var monDTO in monetariaDto)
            {
                monetariaEF.Add(monDTO.MapearEF());
            }

            return monetariaEF;
        }
        public static List<MonetariaDto> MapearListaEF(List<DonacionesMonetarias> MonetariaEF)
        {
            List<MonetariaDto> MonetariaDto = new List<MonetariaDto>();

            foreach (var monEF in MonetariaEF)
            {
                MonetariaDto.Add(new MonetariaDto(monEF));
            }

            return MonetariaDto;
        }
    }
}