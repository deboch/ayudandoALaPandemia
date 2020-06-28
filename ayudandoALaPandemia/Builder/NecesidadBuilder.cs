using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayudandoALaPandemia.ViewModels;
using Repositorios;

namespace ayudandoALaPandemia.Builder
{
    public class NecesidadBuilder
    {
        public Necesidades toNecesidadesEntity(NecesidadDto necesidadDto, int userId)
        {
            Necesidades nuevaNecesidad = new Necesidades();
            nuevaNecesidad.Nombre = necesidadDto.nombre;
            nuevaNecesidad.Descripcion = necesidadDto.descripcion;
            nuevaNecesidad.FechaFin = necesidadDto.fechaFin;
            nuevaNecesidad.TelefonoContacto = necesidadDto.telefono;
            nuevaNecesidad.TipoDonacion = necesidadDto.tipoDonacion == "Monetaria" ? 1 : 0;
            nuevaNecesidad.Foto = "abc.jpg";
            nuevaNecesidad.IdUsuarioCreador = userId;
            nuevaNecesidad.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            
            if (necesidadDto.tipoDonacion == "Monetaria")
            {
                NecesidadesDonacionesMonetarias necesidadMonetaria = new NecesidadesDonacionesMonetarias();
                necesidadMonetaria.CBU = necesidadDto.cbu;
                necesidadMonetaria.Dinero = necesidadDto.dinero;
                nuevaNecesidad.NecesidadesDonacionesMonetarias.Add(necesidadMonetaria);
            }
            if (necesidadDto.insumos.Count > 0)
            {
                foreach (var p in necesidadDto.insumos)
                {
                    NecesidadesDonacionesInsumos necesidadDeInsumos = new NecesidadesDonacionesInsumos();
                    necesidadDeInsumos.Nombre = p.nombre;
                    necesidadDeInsumos.Cantidad = p.cantidad;
                    nuevaNecesidad.NecesidadesDonacionesInsumos.Add(necesidadDeInsumos);
                }
            }

            NecesidadesReferencias necesidadReferencia1 = new NecesidadesReferencias();
            NecesidadesReferencias necesidadReferencia2 = new NecesidadesReferencias();

            necesidadReferencia1.Nombre = necesidadDto.referencia1Nombre;
            necesidadReferencia1.Telefono = necesidadDto.referencia1Telefono;

            necesidadReferencia2.Nombre = necesidadDto.referencia2Nombre;
            necesidadReferencia2.Telefono = necesidadDto.referencia2Telefono;
            nuevaNecesidad.NecesidadesReferencias.Add(necesidadReferencia1);
            nuevaNecesidad.NecesidadesReferencias.Add(necesidadReferencia2);
            return nuevaNecesidad;
        }
    }
}