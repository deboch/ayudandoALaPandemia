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
            /*nuevaNecesidad.Usuarios = usuario;
            nuevaNecesidad.Nombre = necesidad.Nombre;
            nuevaNecesidad.Descripcion = necesidad.Descripcion;
            nuevaNecesidad.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            nuevaNecesidad.FechaFin = necesidad.FechaFin;
            nuevaNecesidad.TelefonoContacto = necesidad.TelefonoContacto;
            nuevaNecesidad.IdUsuarioCreador = necesidad.IdUsuarioCreador;
            nuevaNecesidad.TipoDonacion = necesidad.TipoDonacion;
            nuevaNecesidad.Foto = necesidad.Foto;
            nuevaNecesidad.Denuncias = necesidad.Denuncias;
            nuevaNecesidad.Valoracion = nuevaNecesidad.Valoracion;

            if (necesidad.NecesidadesDonacionesMonetarias.Count > 0)
            {
                foreach (var p in necesidad.NecesidadesDonacionesMonetarias)
                {
                    NecesidadesDonacionesMonetarias necesidadMonetaria = new NecesidadesDonacionesMonetarias();
                    necesidadMonetaria.Dinero = p.Dinero;
                    necesidadMonetaria.CBU = p.CBU;
                    nuevaNecesidad.NecesidadesDonacionesMonetarias.Add(necesidadMonetaria);
                }
            }

            if (necesidad.NecesidadesDonacionesInsumos.Count > 0)
            {
                foreach (var p in necesidad.NecesidadesDonacionesInsumos)
                {
                    NecesidadesDonacionesInsumos necesidadDeInsumos = new NecesidadesDonacionesInsumos();
                    necesidadDeInsumos.Nombre = p.Nombre;
                    necesidadDeInsumos.Cantidad = p.Cantidad;
                    nuevaNecesidad.NecesidadesDonacionesInsumos.Add(necesidadDeInsumos);
                }
            }

            if (necesidad.NecesidadesReferencias.Count > 0)
            {
                foreach (var p in necesidad.NecesidadesReferencias)
                {
                    NecesidadesReferencias necesidadesReferencias = new NecesidadesReferencias();
                    necesidadesReferencias.Nombre = p.Nombre;
                    necesidadesReferencias.Telefono = p.Telefono;
                    nuevaNecesidad.NecesidadesReferencias.Add(necesidadesReferencias);
                }
            }

            nuevaNecesidad.NecesidadesValoraciones = necesidad.NecesidadesValoraciones;*/

            return managerRepository.necesidadesRepository.Crear(necesidad);
        }

        public List<Necesidades> ObtenerTodasMenosPorUserId(int userId)
        {
            return managerRepository.necesidadesRepository.ObtenerTodasMenosPorUserId(userId);
        }

        public DonacionesInsumos donacionInsumo(DonacionesInsumos donacionesInsumos)
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
    }
}