using Repositorios;
using Servicios;
using ServicioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ServicioWeb.Controllers
{
    public class NecesidadController : ApiController
    {
        ManagerRepository managerRepository;
        
        public NecesidadController()
        {
            this.managerRepository = new ManagerRepository();
        }

        public List<NecesidadDto> Get()
        {
            List<Necesidades> necesidadesEF = managerRepository.necesidadesRepository.ObtenerTodos();
            return NecesidadDto.MapearListaEF(necesidadesEF);
        }

        public NecesidadDto Get(int id)
        {
            Necesidades necesidadEF = managerRepository.necesidadesRepository.ObtenerPorId(id);
            return new NecesidadDto(necesidadEF);
        }
    }
}