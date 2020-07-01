using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Models
{
    public class NecesidadDto
    {
        public int idNecesidad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public DateTime fechaCreacion { get; set; }
        public DateTime fechaFin { get; set; }
        public string telefono { get; set; }
        public int tipoDonacion { get; set; }
        public string foto { get; set; }
        public decimal dinero { get; set; }
        public string cbu { get; set; }
        public List<InsumosDto> insumos { get; set; }
        public string referencia1Nombre { get; set; }
        public string referencia2Nombre { get; set; }
        public string referencia1Telefono { get; set; }
        public string referencia2Telefono { get; set; }
        public int idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public decimal valoracion { get; set; }
        public NecesidadDto()
        {

        }
        public NecesidadDto(Necesidades necesidadEntidad)
        {
            this.idNecesidad = necesidadEntidad.IdNecesidad;
            this.nombre = necesidadEntidad.Nombre;
            this.idUsuario = necesidadEntidad.IdUsuarioCreador;
            this.descripcion = necesidadEntidad.Descripcion;
            this.fechaFin = necesidadEntidad.FechaFin;
            this.fechaCreacion = necesidadEntidad.FechaCreacion;
            this.telefono = necesidadEntidad.TelefonoContacto;
            this.tipoDonacion = necesidadEntidad.TipoDonacion;
            this.foto = necesidadEntidad.Foto;
            this.valoracion = (decimal)necesidadEntidad.Valoracion;
            
        }
        public Necesidades MapearEF()
        {
            Necesidades p = new Necesidades();
            p.IdNecesidad = this.idNecesidad;
            p.Descripcion = this.descripcion;
            p.IdUsuarioCreador = this.idUsuario;
            p.Nombre = this.nombre;
            p.TipoDonacion = this.tipoDonacion;
            p.Foto = this.foto;
            p.FechaCreacion = this.fechaCreacion;
            p.FechaFin = this.fechaFin;
            p.Valoracion = this.valoracion;
            p.TelefonoContacto = this.telefono;
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