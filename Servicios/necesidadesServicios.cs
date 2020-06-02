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
        public int Borrar(Necesidades obj)
        {
            throw new NotImplementedException();
        }

        public int Crear(Necesidades necesidad)
        {
            Necesidades nuevaNecesidad = new Necesidades();

            Usuarios usuario = managerRepository
                                .usuarioRepository
                                .ObtenerPorId(necesidad.IdUsuarioCreador);

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
            nuevaNecesidad.NecesidadesDonacionesInsumos = necesidad.NecesidadesDonacionesInsumos;
            nuevaNecesidad.NecesidadesDonacionesMonetarias = necesidad.NecesidadesDonacionesMonetarias;
            nuevaNecesidad.NecesidadesReferencias = necesidad.NecesidadesReferencias;
            nuevaNecesidad.NecesidadesValoraciones = necesidad.NecesidadesValoraciones;

            return managerRepository.necesidadesRepository.Crear(nuevaNecesidad);
        }

        public Necesidades Modificar(Necesidades obj)
        {
            throw new NotImplementedException();
        }

        public Necesidades ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Necesidades> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}