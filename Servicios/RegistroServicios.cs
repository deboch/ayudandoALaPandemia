using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Servicios
{
    public class RegistroServicios
    {
       private static List<Usuarios> listaUsuarios = new List<Usuarios>();
        

        public static void altaUsuario(Usuarios u)
        {
            u.Id = generaId(u);

            listaUsuarios.Add(u);
        }
        private static int generaId(Usuarios u)
        {
            listaUsuarios = LoginServicios.traerTodosLosUsuariosActivos();

            int id = 1;
            if (listaUsuarios.Count > 0)
            {
                id = listaUsuarios.Count + 1;
            }
            return id;
        }

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

        public static List<Usuarios> traerTodosLosAdministradores()
        {
            List<Usuarios> traerTodosLosAdministradores = new List<Usuarios>();
            foreach (var item in traerTodosLosAdministradores)
            {
                if (item.TipoUsuario == "Administrador" && item.Activo == true)
                {
                    traerTodosLosAdministradores.Add(item);
                }
            }
            return traerTodosLosAdministradores;
        }



        public static void existeUsuario(bool resultado)
        {
            bool isValad = resultado;
        }

        public static bool IsValid(Usuarios u)
        {
            List<Usuarios> misUsuarios = RegistroServicios.traerTodosLosUsuariosActivos();
            bool resultado = true;

            foreach (var item in misUsuarios)
            {
                if (item.Username.Equals(u.Username))
                {
                    return !resultado;
                }
            }
            return resultado;
        }
    }


}
}
