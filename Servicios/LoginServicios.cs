
using System.Collections.Generic;
using Entidades;

namespace Servicios
{
    public class LoginServicios
    {
        private static List<Usuario> listaUsuario = new List<Usuario>();

        public static List<Usuario> traerTodosLosUsuarioActivos()
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
        }

        public static bool logear(Usuario u)
        {
            List<Usuario> miListaUsuario = traerTodosLosUsuarioActivos();
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
