using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Models
{
    public class NecesidadDto
    {
        public int IdNecesidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaFin { get; set; }
        public string TelefonoContacto { get; set; }
        public int TipoDonacion { get; set; }
        public string Foto { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int Estado { get; set; }
        public Nullable<decimal> Valoracion { get; set; }
        public NecesidadDto()
        {

        }
        public NecesidadDto(Necesidades necesidadEntidad)
        {
            this.IdNecesidad = necesidadEntidad.IdNecesidad;
            this.Nombre = necesidadEntidad.Nombre;
            this.IdUsuarioCreador = necesidadEntidad.IdUsuarioCreador;
            this.Descripcion = necesidadEntidad.Descripcion;
            this.FechaFin = necesidadEntidad.FechaFin;
            this.FechaCreacion = necesidadEntidad.FechaCreacion;
            this.TelefonoContacto = necesidadEntidad.TelefonoContacto;
            this.TipoDonacion = necesidadEntidad.TipoDonacion;
            this.Foto = necesidadEntidad.Foto;
            this.Estado = necesidadEntidad.Estado;
            if (necesidadEntidad.Valoracion == null)
            {
                this.Valoracion = 0;
            }
            else
            {
                this.Valoracion = necesidadEntidad.Valoracion;
            }


        }
        public Necesidades MapearEF()
        {
            Necesidades p = new Necesidades();
            p.IdNecesidad = this.IdNecesidad;
            p.Descripcion = this.Descripcion;
            p.IdUsuarioCreador = this.IdUsuarioCreador;
            p.Nombre = this.Nombre;
            p.TipoDonacion = this.TipoDonacion;
            p.Foto = this.Foto;
            p.FechaCreacion = this.FechaCreacion;
            p.FechaFin = this.FechaFin;
            p.Valoracion = this.Valoracion;
            p.TelefonoContacto = this.TelefonoContacto;
            p.Estado = this.Estado;
            return p;
        }
        public static List<Necesidades> MapearListaDTO(List<NecesidadDto> necesidadDTO)
        {
            List<Necesidades> necesidadEF = new List<Necesidades>();

            foreach (var necDTO in necesidadDTO)
            {
                necesidadEF.Add(necDTO.MapearEF());
            }

            return necesidadEF;
        }
        public static List<NecesidadDto> MapearListaEF(List<Necesidades> NecesidadEF)
        {
            List<NecesidadDto> NecesidadDto = new List<NecesidadDto>();

            foreach (var prodEF in NecesidadEF)
            {
                NecesidadDto.Add(new NecesidadDto(prodEF));
            }

            return NecesidadDto;
        }
    }

}