using ayudandoALaPandemia.ViewModels;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.Builder
{
    public class DonacionMonetariaBuilder
    {
        public DonacionMonetariaBuilder()
        {
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
    }
}