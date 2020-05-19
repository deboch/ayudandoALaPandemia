using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class LoginServicios
    {
        private static List<Usuarios> listaUsuarios = new List<Usuarios>();

        public static List<Usuarios> traerTodosLosUsuariosActivos()
        {
            List<Usuarios> miListaDeUsuariosActivos = new List<Usuarios>();
            foreach (var item in miListaDeUsuariosActivos)
            {
                if (item.TipoUsuario == "Usuario" && item.Activo == true)
                {
                    miListaDeUsuariosActivos.Add(item);
                }
            }
            return miListaDeUsuariosActivos;
        }

        public static bool logear(Usuarios u)
        {
            List<Usuarios> miListaUsuarios = LoginServicios.traerTodosLosUsuariosActivos();
            bool logeado = true;
            foreach (var user in miListaUsuarios)
            {
                if ((user.Username == u.Username || user.Email == u.Email) && user.Password == u.Password)
                {
                    return logeado;
                }
            }
            return !logeado;
        }

    }
}
