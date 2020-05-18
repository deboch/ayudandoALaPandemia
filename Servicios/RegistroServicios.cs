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
            int id = 1;
            if (listaUsuarios.Count > 0)
            {
                id = listaUsuarios.Count + 1;
            }
            return id;
        }

       
    }
}
