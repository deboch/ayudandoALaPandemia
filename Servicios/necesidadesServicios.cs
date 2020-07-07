using System;
using System.Collections.Generic;
using System.Linq;
using Repositorios;

namespace Servicios
{
    public class NecesidadesServicios : ICrud<Necesidades>
    {
        ManagerRepository managerRepository = new ManagerRepository();
        public int Borrar(int id)
        {
            return managerRepository.necesidadesRepository.Borrar(id);
        }

        public int Crear(Necesidades necesidad)
        {
            Necesidades nuevaNecesidad = new Necesidades();

            Usuarios usuario = managerRepository.usuarioRepository.ObtenerPorId(necesidad.IdUsuarioCreador);
            necesidad.Usuarios = usuario;

            return managerRepository.necesidadesRepository.Crear(necesidad);
        }

        public NecesidadesValoraciones ObtenerValoracionPorUsuarioNecesidad(int idUsuario, int idNecesidad)
        {
            return managerRepository.necesidadesRepository.ObtenerValoracionPorUsuarioNecesidad(idUsuario, idNecesidad);
        }

        public List<Necesidades> ObtenerNecesidadesSegunActivacion(bool isActive, int userId)
        {
            return managerRepository.necesidadesRepository.ObtenerNecesidadesSegunActivacion(isActive, userId);
        }

        public List<Necesidades> ObtenerTodasMenosPorUserId(int userId)
        {
            return managerRepository.necesidadesRepository.ObtenerTodasMenosPorUserId(userId);
        }

        public int ObtenerSumaTotalDeValoraciones(int idNecesidad)
        {
            return managerRepository.necesidadesRepository.ObtenerSumaTotalDeValoraciones(idNecesidad);
        }

        public List<DonacionesInsumos> donacionInsumo(List<DonacionesInsumos> donacionesInsumos)
        {
            return managerRepository.necesidadesRepository.donacionInsumo(donacionesInsumos);
        }

        public DonacionesMonetarias donacionMonetaria(DonacionesMonetarias donacionesMonetarias)
        {
            donacionesMonetarias.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            return managerRepository.necesidadesRepository.donacionMonetaria(donacionesMonetarias);
        }

        public bool Valorar(int like, int userId, int idNecesidad)
        {

            bool valoracion = managerRepository.necesidadesRepository.Valorar(like, userId, idNecesidad);
            int calcularPorcentaje = managerRepository.necesidadesRepository.CalcularPorcentaje(idNecesidad);
            return valoracion;
        }

        public int CalcularPorcentaje(int idNecesidad)
        {
            int valoracionesLike =
                managerRepository
                .necesidadesRepository
                .obtenerTotalValoraciones(idNecesidad)
                .Where(v => v.Valoracion == true)
                .ToList()
                .Count;
            int valoracionesTotal =
                managerRepository
                .necesidadesRepository
                .obtenerTotalValoraciones(idNecesidad)
                .ToList()
                .Count;
            int porcentaje = (valoracionesLike / valoracionesTotal) * 100;
            return porcentaje;
        }

        public Necesidades Modificar(Necesidades necesidad)
        {
            return managerRepository.necesidadesRepository.Modificar(necesidad);
        }

        public Necesidades ObtenerPorId(int id)
        {
            return managerRepository.necesidadesRepository.ObtenerPorId(id);
        }

        public List<Necesidades> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public List<Necesidades> ObtenerPorUserId(int userId)
        {
            return managerRepository.necesidadesRepository.ObtenerPorUserId(userId);
        }
        public List<Necesidades> GetNecesidades()
        {
            var listaOrdenada = managerRepository.necesidadesRepository
                .ObtenerTodos()
                .ToList();

            return listaOrdenada;
        }
        public int CrearDenuncia(Denuncias denuncia)
        {
            return managerRepository.necesidadesRepository.CrearDenuncia(denuncia);
        }
        public List<Denuncias> ObtenerDenunciasPorUserId(int userId)
        {
            return managerRepository.necesidadesRepository.ObtenerDenunciasPorUserId(userId);
        }

        public List<DonacionesInsumos> ObtenerDonacionesInsumosPorUserId(int userId)
        {
            return managerRepository.donacionesInsumosRepository.ObtenerDonacionesInsumosPorUserId(userId);
        }

        public List<DonacionesMonetarias> ObtenerDonacionesMonetariasPorUserId(int userId)
        {
            return managerRepository.donacionesMonetariasRepository.ObtenerDonacionesMonetariasUserPorId(userId);
        }
    }
}