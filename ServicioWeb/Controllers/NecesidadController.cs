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

        public List<DonacionesDto> Get(int id)
        {
            List<DonacionesDto> lista = new List<DonacionesDto>();
            
            //managerRepository.donacionesMonetariasRepository.ObtenerDonacionesMonetariasUserPorId(id)[0];
            List<Necesidades> necesidadesEF = managerRepository.donacionesInsumosRepository.ObtenerDonacionesInsumosPorUserId(id).Select(o => o.NecesidadesDonacionesInsumos).Select(o=> o.Necesidades).ToList();
            necesidadesEF.AddRange(managerRepository.donacionesMonetariasRepository.ObtenerDonacionesMonetariasUserPorId(id).Select(o => o.NecesidadesDonacionesMonetarias).Select(o=> o.Necesidades).ToList());

            //List<Necesidades> necesidadesEF = managerRepository.necesidadesRepository.ObtenerPorUserId(id);
            
            foreach (var p in necesidadesEF.Distinct())
            {
                DonacionesDto donacionesDto = new DonacionesDto();
                donacionesDto.fechaNecesidad = p.FechaCreacion;
                donacionesDto.nombre = p.Nombre;
                donacionesDto.idNecesidad = p.IdNecesidad;
                donacionesDto.estado = p.Estado;
                donacionesDto.tipoDonacion = p.TipoDonacion;
                if (p.TipoDonacion == 1)
                {
                    NecesidadesDonacionesMonetarias necesidadMonetaria = managerRepository.donacionesMonetariasRepository.obtenerPorNecesidadId(p.IdNecesidad);
                    decimal totalRecaudado = managerRepository.donacionesMonetariasRepository.obtenerDinero(necesidadMonetaria.IdNecesidadDonacionMonetaria);
                    donacionesDto.totalDonacion = necesidadMonetaria.Dinero;
                    donacionesDto.totalRecaudado = totalRecaudado;
                } else
                {
                    List<NecesidadesDonacionesInsumos> necesidadInsumos = managerRepository.donacionesInsumosRepository.ObtenerPorNecesidadId(p.IdNecesidad);
                    foreach(var c in necesidadInsumos)
                    {
                        int totalDonado = managerRepository.donacionesInsumosRepository.obtenerTotalDeDonaciones(c.IdNecesidadDonacionInsumo);
                        InsumosDto insumoDto = new InsumosDto();
                        insumoDto.nombre = c.Nombre;
                        insumoDto.cantidadPedida = c.Cantidad;
                        insumoDto.totalDonado = totalDonado;
                        donacionesDto.listaInsumos.Add(insumoDto);
                    }
                }
                lista.Add(donacionesDto);
            }
            return lista;
        }
    }
}