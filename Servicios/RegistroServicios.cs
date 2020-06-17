using Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

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

        public int validoUsuario(Usuarios u)
        {
            var validoUser = managerRepository.usuarioRepository.obtenerUsuario(u.Email);

            if(validoUser == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int Crear(Usuarios u)
        {

        try
        {
            //u.IdUsuario = generaId();
            seteoLosNotNull(u);
            //hasheo clave
            //MD5Hash(u);
            // metodo que envia token por email
            int userId = managerRepository.usuarioRepository.Crear(u);
            // Guardo el usuario
            //u.Password = MD5Hash(u.Password);
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
        }

            {// el mail ya existe
                return 0;
            }
            return 0;
        }

        /* public int generaId()
         {
         List<Usuarios> listaUsuarios = managerRepository.usuarioRepository.traerTodosLosUsuarios();

         int id = 1;
         if (listaUsuarios.Count > 0)
         {
             id = listaUsuarios.Count + 1;
         }
         return id;
         }*/

        public Usuarios Modificar(Usuarios obj)
        {
            throw new NotImplementedException();
        }

        public void seteoLosNotNull(Usuarios u)
        {
            u.FechaCracion = DateTime.Now;
            u.FechaNacimiento = DateTime.Now;
            u.TipoUsuario = 1;
            u.Token = generoToken();
            //u.Password = MD5Hash(u.Password);
        }

        public Usuarios ObtenerPorId(int id)
        {
            return managerRepository.usuarioRepository.ObtenerPorId(id);
        }

        public List<Usuarios> ObtenerTodos()
        {
            throw new NotImplementedException();
        }


        public string generoToken()
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(6);
            for (int i = 0; i < 6; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        public string MD5Hash(string poronga)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(poronga));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }


    }
}
