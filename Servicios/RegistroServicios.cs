using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Repositorios;


namespace Servicios
{
    public class RegistroServicios : ICrud<Usuarios>
    {
        private static List<Usuarios> listaUsuario = new List<Usuarios>();
        ManagerRepository managerRepository = new ManagerRepository();

        public int Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool validoUsuarioNoExistente(Usuarios u)
        {
            var validoSiUserExiste = managerRepository.usuarioRepository.obtenerUsuario(u.Email);
            var validoUserNameExistente = managerRepository.usuarioRepository.obtenerUsuarioPorUserName(u.UserName);
            if(validoSiUserExiste == null && validoUserNameExistente == null)
            {
                return true;
            }
            else{
                return false;
            }
        }
        public bool matcheoClaves(string password, string confirm)
        {
            if (password == confirm)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void generoTokenNuevo(Usuarios user, string token)
        {
            managerRepository.usuarioRepository.generoTokenNuevo(user,token);
        }

        public int Crear(Usuarios u)
        {
            try
            {
                seteoLosNotNull(u);
                int userId = managerRepository.usuarioRepository.Crear(u);
                managerRepository.usuarioRepository.MD5Hash(u);
                return userId;
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
                return 0;
            }
        }

        public void hacerAdmin(int id)
        {
            managerRepository.usuarioRepository.hacerAdmin(id);
        }

        public List<Usuarios> obtengoUsuariosTipo1()
        {
            return managerRepository.usuarioRepository.obtengoUsuariosTipo1();
        }

        public void activoToken(Usuarios user)
        {
            managerRepository.usuarioRepository.activoToken(user);
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

        public Usuarios Modificar(Usuarios user)
        {
            return managerRepository.usuarioRepository.Modificar(user);
        }

        public Usuarios Editar(Usuarios user, int id) {
            return managerRepository.usuarioRepository.Editar(user, id);
        }

        public void seteoLosNotNull(Usuarios u)
        {
            u.FechaCracion = DateTime.Now;
            u.TipoUsuario = 1;
            u.Token = generoToken();
            u.Activo = false;
        }

        public Usuarios ObtenerPorId(int id)
        {
            return managerRepository.usuarioRepository.ObtenerPorId(id);
        }

        public List<Usuarios> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public Usuarios obtenerPorToken(string token)
        {
            return managerRepository.usuarioRepository.obtenerPorToken(token);
        }


        public string generoToken()
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder result = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        public bool mas18(DateTime dateEnviado)
        {
            var bday = dateEnviado;
            var resta = DateTime.Today - bday;
            var año = DateTime.MinValue.Add(resta).Year - 1;
            return año >= 18;
        }

        public bool validoClave(string password)
        {
            if (string.IsNullOrEmpty(password) ||
                password.Length > 50 ||
                password.Length < 8)
            {
                return false;
            }
            else if (!Regex.IsMatch(password, "[A-Z]") ||
                !Regex.IsMatch(password, "[a-z]") ||
                !Regex.IsMatch(password, "[0-9]"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
