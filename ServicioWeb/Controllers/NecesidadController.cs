using Repositorios;
using Servicios;
using ServicioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioWeb.Controllers
{
    public class NecesidadController : ApiController
    {
            NecesidadesServicios necesidadesServicios;
            public NecesidadController()
            {
                Context ctx = new Context();
                necesidadesServicios = new NecesidadesServicios(ctx);
            }

            public List<NecesidadDto> Get()
            {
                List<Necesidades> necesidadesEF = necesidadesServicios.ObtenerTodos();

                return NecesidadDto.MapearListaEF(necesidadesEF);
            }

            [HttpGet]
            public NecesidadDto Get(int id)
            {
                Necesidades necesidadEF = necesidadesServicios.ObtenerPorId(id);

                return new NecesidadDto(necesidadEF);
            }
        
    }
}
