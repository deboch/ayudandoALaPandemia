using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ServicioWeb.Models;

namespace ServicioWeb.Controllers
{
    public class InsumosController : ApiController
    {
        ManagerRepository managerRepository;

        public InsumosController()
        {
            this.managerRepository = new ManagerRepository();
        }
        public List<InsumosDto> Get()
        {
            List<DonacionesInsumos> donacionesInsumosEF = managerRepository.necesidadesRepository.ObtenerDonacionesInsumos();
            return InsumosDto.MapearListaEF(donacionesInsumosEF);
        }
        public List<InsumosDto> Get(int idUsuario)
        {
            List<DonacionesInsumos> donacionesInsumosEF = managerRepository.necesidadesRepository.ObtenerDonacionesInsumosPorUserId(idUsuario);
            return InsumosDto.MapearListaEF(donacionesInsumosEF);
        }
    }
}