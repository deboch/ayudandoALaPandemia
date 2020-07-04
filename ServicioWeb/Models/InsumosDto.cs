using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Models
{
    public class InsumosDto
    {
        public int id { get; set; }
        public int idNecesidad { get; set; }
        public int idUsuario { get; set; }
        public int cantidad { get; set; }

        public InsumosDto()
        {

        }

        public InsumosDto(DonacionesInsumos insumos)
        {
            this.id = insumos.IdDonacionInsumo;
            this.idNecesidad = insumos.IdNecesidadDonacionInsumo;
            this.idUsuario = insumos.IdUsuario;
            this.cantidad = insumos.Cantidad;
        }
        public DonacionesInsumos MapearEF()
        {
            DonacionesInsumos p = new DonacionesInsumos();
            this.id = p.IdDonacionInsumo;
            this.idNecesidad = p.IdNecesidadDonacionInsumo ;
            this.idUsuario = p.IdUsuario ;
            this.cantidad = p.Cantidad;
            return p;
        }
        public List<DonacionesInsumos> MapearListaDto(List<InsumosDto> insumosDto)
        {
            List<DonacionesInsumos> insumosEF = new List<DonacionesInsumos>();

            foreach (var insumoDTO in insumosDto)
            {
                insumosEF.Add(insumoDTO.MapearEF());
            }

            return insumosEF;
        }
        public static List<InsumosDto> MapearListaEF(List<DonacionesInsumos> InsumosEF)
        {
            List<InsumosDto> InsumosDto = new List<InsumosDto>();

            foreach (var insumoEF in InsumosEF)
            {
                InsumosDto.Add(new InsumosDto(insumoEF));
            }

            return InsumosDto;
        }
    }
}