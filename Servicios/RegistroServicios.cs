using Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class RegistroServicios : ICrud<Usuarios>
    {
        private static List<Usuarios> listaUsuario = new List<Usuarios>();
        ManagerRepository managerRepository = new ManagerRepository();


        public int Borrar(Usuarios obj)
        {
            throw new NotImplementedException();
        }

        public int Crear(Usuarios u)
        {
            Usuarios userPrueba = new Usuarios();
            // Valido si ya existe un usuario con ese userName y con ese Mail
            var validoUser = managerRepository.usuarioRepository.obtenerUsuario(u.Email);
            //     u = managerRepository.usuarioRepository.obtenerUsuarioPorUserName(u.UserName);

            //     if(u.UserName == null && u.Email == null)
            if (validoUser == null)
            {
                try
                {
                    u.IdUsuario = generaId();
                    nulleoLosNotNull(u);
                    u.FechaCracion = DateTime.Now;
                    // Guardo el usuario
                    return managerRepository.usuarioRepository.Crear(u);
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }
            return 0;
        }

        public int generaId()
        {
        List<Usuarios> listaUsuarios = managerRepository.usuarioRepository.traerTodosLosUsuarios();

        int id = 1;
        if (listaUsuarios.Count > 0)
        {
            id = listaUsuarios.Count + 1;
        }
        return id;
        }

        public Usuarios Modificar(Usuarios obj)
        {
            throw new NotImplementedException();
        }

        public void nulleoLosNotNull(Usuarios u)
        {
            u.FechaNacimiento = DateTime.Now;
            u.TipoUsuario = 1;
            u.Token = "abc123";
        }

        public Usuarios ObtenerPorId(int id)
        {
            return managerRepository.usuarioRepository.ObtenerPorId(id);
        }

        public List<Usuarios> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
