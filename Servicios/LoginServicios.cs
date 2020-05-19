using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Servicios
{
    class LoginServicios
    {
        private static List<Usuario> listaUsuario = new List<Usuario>();

        public static List<Usuario> traerTodosLosUsuarioActivos()
        {
            List<Usuario> miListaDeUsuarioActivos = new List<Usuario>();
            foreach (var item in miListaDeUsuarioActivos)
            {
                if (item.TipoUsuario == "Usuario" && item.Activo == true)
                {
                    miListaDeUsuarioActivos.Add(item);
                }
            }
            return miListaDeUsuarioActivos;
        }

        public static bool logear(Usuario u)
        {
            List<Usuario> miListaUsuario = LoginServicios.traerTodosLosUsuarioActivos();
            bool logeado = true;
            foreach (var user in miListaUsuario)
            {
                if ((user.UserName == u.UserName || user.Email == u.Email) && user.Password == u.Password)
                {
                    return logeado;
                }
            }
            return !logeado;
        }
    }
}
