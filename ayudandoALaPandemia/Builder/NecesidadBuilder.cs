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
            nuevaNecesidad.IdNecesidad = necesidadDto.Id;
            nuevaNecesidad.Nombre = necesidadDto.nombre;
            nuevaNecesidad.Descripcion = necesidadDto.descripcion;
            nuevaNecesidad.FechaFin = necesidadDto.fechaFin;
            nuevaNecesidad.TelefonoContacto = necesidadDto.telefono;
            nuevaNecesidad.TipoDonacion = necesidadDto.tipoDonacion == "1" ? 1 : 0;
            nuevaNecesidad.Foto = necesidadDto.foto;
            nuevaNecesidad.IdUsuarioCreador = userId;
            nuevaNecesidad.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            nuevaNecesidad.Estado = 1;

            if (nuevaNecesidad.TipoDonacion == 1)
            {
                NecesidadesDonacionesMonetarias necesidadMonetaria = new NecesidadesDonacionesMonetarias();
                necesidadMonetaria.IdNecesidadDonacionMonetaria = necesidadDto.idMonetaria;
                necesidadMonetaria.CBU = necesidadDto.cbu;
                necesidadMonetaria.Dinero = necesidadDto.dinero;
                nuevaNecesidad.NecesidadesDonacionesMonetarias.Add(necesidadMonetaria);
            } else
            {
                if (necesidadDto.dinero == 0 && necesidadDto.insumos.Count > 0)
                {
                    necesidadDto.insumos.RemoveAll(v => v.nombre == null);
                    foreach (var p in necesidadDto.insumos)
                    {
                        NecesidadesDonacionesInsumos necesidadDeInsumos = new NecesidadesDonacionesInsumos();
                        necesidadDeInsumos.IdNecesidadDonacionInsumo = p.id;
                        necesidadDeInsumos.Nombre = p.nombre;
                        necesidadDeInsumos.Cantidad = p.cantidad;
                        nuevaNecesidad.NecesidadesDonacionesInsumos.Add(necesidadDeInsumos);
                    }
                }
            }

            if (necesidadDto.referencias.Count > 0)
            {
                necesidadDto.referencias.RemoveAll(v => v.nombre == null);
                foreach (var p in necesidadDto.referencias)
                {
                    NecesidadesReferencias necesidadReferencias = new NecesidadesReferencias();
                    necesidadReferencias.IdReferencia = p.id;
                    necesidadReferencias.Nombre = p.nombre;
                    necesidadReferencias.Telefono = p.telefono;
                    nuevaNecesidad.NecesidadesReferencias.Add(necesidadReferencias);
                }
            }

            return nuevaNecesidad;
        }

        internal NecesidadDto necesidadDtoParaDetalle(Necesidades necesidad, Usuarios usuario, NecesidadesValoraciones valoracion)
        {
            NecesidadDto necesidadDto = new NecesidadDto();
            
            necesidadDto.ApellidoUsuario = usuario.Apellido;
            necesidadDto.NombreUsuario = usuario.Nombre;
            
            necesidadDto.Id = necesidad.IdNecesidad;
            necesidadDto.nombre = necesidad.Nombre;
            necesidadDto.descripcion = necesidad.Descripcion;
            necesidadDto.fechaFin = necesidad.FechaFin;
            necesidadDto.telefono = necesidad.TelefonoContacto;
            necesidadDto.tipoDonacion = necesidad.TipoDonacion.ToString();
            necesidadDto.foto = necesidad.Foto;
            if (valoracion != null)
            {
                necesidadDto.valoracion = valoracion.Valoracion;
            }
            else
            {
                necesidadDto.valoracion = null;
            }

            if (necesidad.TipoDonacion == 1)
            {
                necesidadDto.tipoDonacion = "Monetaria";
                foreach (var p in necesidad.NecesidadesDonacionesMonetarias)
                {
                    necesidadDto.dinero = p.Dinero;
                }
            }
            else {
                necesidadDto.tipoDonacion = "Insumo";
            }
            return necesidadDto;
        }

        internal List<DonacionesInsumos> transformarADonacionesInsumos (NecesidadDto necesidadDto)
        {
            List<DonacionesInsumos> lista = new List<DonacionesInsumos>();
            foreach (var p in necesidadDto.insumos)
            {
                if (p.cantidad > 0)
                {
                    DonacionesInsumos donacion = new DonacionesInsumos();
                    donacion.IdNecesidadDonacionInsumo = p.id;
                    donacion.IdUsuario = necesidadDto.idUsuario;
                    donacion.Cantidad = p.cantidad;
                    lista.Add(donacion);
                }
            }
            return lista;
        }

        internal NecesidadDto trasnformarNecesidadANecesidadDto(Necesidades necesidad)
        {
            NecesidadDto necesidadDto = new NecesidadDto();
            necesidadDto.Id = necesidad.IdNecesidad;
            necesidadDto.nombre = necesidad.Nombre;
            necesidadDto.descripcion = necesidad.Descripcion;
            necesidadDto.fechaFin = necesidad.FechaFin;
            necesidadDto.telefono = necesidad.TelefonoContacto;
            necesidadDto.tipoDonacion = necesidad.TipoDonacion == 1 ? "1" : "0";
            necesidadDto.foto = necesidad.Foto;

            if (necesidadDto.tipoDonacion == "1")
            {
                foreach (var p in necesidad.NecesidadesDonacionesMonetarias)
                {
                    necesidadDto.idMonetaria = p.IdNecesidadDonacionMonetaria;
                    necesidadDto.cbu = p.CBU;
                    necesidadDto.dinero = p.Dinero;
                }
            } else
            {
                if (necesidad.NecesidadesDonacionesInsumos.Count > 0)
                {
                    foreach (var p in necesidad.NecesidadesDonacionesInsumos)
                    {
                        InsumosDto insumoDto = new InsumosDto();
                        insumoDto.id = p.IdNecesidadDonacionInsumo;
                        insumoDto.nombre = p.Nombre;
                        insumoDto.cantidad = p.Cantidad;
                        necesidadDto.insumos.Add(insumoDto);
                    }
                }
            }

            necesidadDto.referencias.RemoveAll(v => v.nombre == null);
            foreach (var p in necesidad.NecesidadesReferencias)
            {
                ReferenciaDto referenciaDto = new ReferenciaDto();
                referenciaDto.id = p.IdReferencia;
                referenciaDto.nombre = p.Nombre;
                referenciaDto.telefono = p.Telefono;
                necesidadDto.referencias.Add(referenciaDto);
            }
            return necesidadDto;
        }
    }
}