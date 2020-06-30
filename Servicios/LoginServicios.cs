
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Repositorios;

namespace Servicios
{
    public class LoginServicios
    {
        private static List<Usuarios> listaUsuario = new List<Usuarios>();
        ManagerRepository managerRepository = new ManagerRepository();


        public Usuarios obtenerPorMail(string email)
        {
            return managerRepository.usuarioRepository.obtenerUsuario(email);
        }

        /*public static List<Usuario> traerTodosLosUsuarioActivos()
        {
            List<Usuario> miListaDeUsuarioActivos = new List<Usuario>();
            Usuario usuarioActivo1 = new Usuario(1, "user1", "apellido", "usuarioActivo1", "act@gmail.com", "contraseña","", true, "35656");
            miListaDeUsuarioActivos.Add(usuarioActivo1);
            foreach (var item in miListaDeUsuarioActivos)
            {
                if (item.TipoUsuario == "Usuario" && item.Activo == true)
                {
                    miListaDeUsuarioActivos.Add(item);
                }
            }
            return miListaDeUsuarioActivos;
        }*/

        public Usuarios logear(Usuarios u)
        {
            u.Password = hasheoParaLogear(u.Password);  

            Usuarios userMail = managerRepository.usuarioRepository.obtenerUsuario(u.Email);

            if(userMail.Email == u.Email && userMail.Password == u.Password) 
            {
                return userMail;
            }else
            {
                return null;
            }
        }

        public string hasheoParaLogear(string password)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return password = hash.ToString();
        }

    }
}
