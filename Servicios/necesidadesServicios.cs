using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;
using System.Web;
using System.Net.Http;

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

            nuevaNecesidad.Usuarios = usuario;
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

            nuevaNecesidad.NecesidadesValoraciones = necesidad.NecesidadesValoraciones;

            return managerRepository.necesidadesRepository.Crear(nuevaNecesidad);
        }

        public bool Valorar(int like, int userId, int idNecesidad)
        {
            return managerRepository.necesidadesRepository.Valorar(like, userId, idNecesidad);
        }

        public Necesidades Modificar(Necesidades necesidad)
        {
            return managerRepository.necesidadesRepository.Modificar(necesidad);
        }

        public Necesidades ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Necesidades> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public List<Necesidades> ObtenerPorUserId(int userId)
        {
            return managerRepository.necesidadesRepository.ObtenerPorUserId(userId);
        }
    }
}