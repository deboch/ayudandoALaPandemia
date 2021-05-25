using ayudandoALaPandemia.ViewModels;
using Repositorios;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.Builder
{
    public class DonacionMonetariaBuilder
    {
        public DonacionesMonetariasServicios donacionesMonetariasServicios;
        public DonacionMonetariaBuilder()
        {
            this.donacionesMonetariasServicios = new DonacionesMonetariasServicios();
        }

        internal DonacionesMonetarias dtoAEntidad(DonacionMonetariaDto donacionMonetariaDto)
        {
            DonacionesMonetarias donacionMonetaria = new DonacionesMonetarias();
            donacionMonetaria.IdUsuario = donacionMonetariaDto.IdUsuario;
            donacionMonetaria.IdNecesidadDonacionMonetaria = donacionMonetariaDto.IdNecesidadDonacionMonetaria;
            donacionMonetaria.Dinero = donacionMonetariaDto.dinero;
            donacionMonetaria.ArchivoTransferencia = donacionMonetariaDto.comprobante;
            return donacionMonetaria;
        }

        internal DonacionMonetariaDto entidadADto(int idNecesidad, int userId)
        {
            DonacionMonetariaDto donacionMonetariaDto = new DonacionMonetariaDto();
            NecesidadesDonacionesMonetarias donacion = donacionesMonetariasServicios.ObtenerPorNecesidadId(idNecesidad);
            decimal donacionesMonetarias = donacionesMonetariasServicios.ObtenerTodasLasDonaciones(donacion);
            donacionMonetariaDto.totalRestante = donacion.Dinero - donacionesMonetarias;
            donacionMonetariaDto.totalDeDinero = donacion.Dinero;
            donacionMonetariaDto.IdNecesidadDonacionMonetaria = donacion.IdNecesidadDonacionMonetaria;
            donacionMonetariaDto.IdUsuario = userId;
            return donacionMonetariaDto;
        }

    }
}