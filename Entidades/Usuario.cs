using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Usuario
    {
	
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime FechaNacimiento { get; set; }
           
            public string UserName { get; set; }
           
            public string Email { get; set; }
           
            public string Password { get; set; }
            public string TipoUsuario { get; set; }
            public DateTime FechaCreacion { get; set; }
            public bool Activo { get; set; }
            public string Token { get; set; }
    
        public Usuario(int id, string nombre, string apellido, DateTime fechaNacimiento, string userName, string email, string password, string tipoUsuario, DateTime fechaCreacion, bool activo, string token)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            UserName = userName;
            Email = email;
            Password = password;
            TipoUsuario = tipoUsuario;
            FechaCreacion = fechaCreacion;
            Activo = activo;
            Token = token;
        }
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

        public static List<Usuario> traerTodosLosAdministradores()
        {
            List<Usuario> traerTodosLosAdministradores = new List<Usuario>();
            foreach (var item in traerTodosLosAdministradores)
            {
                if (item.TipoUsuario == "Administrador" && item.Activo == true)
                {
                    traerTodosLosAdministradores.Add(item);
                }
            }
            return traerTodosLosAdministradores;
        }

        public class existeUsuario : ValidationAttribute
        {
            List<Usuario> misUsuario = traerTodosLosUsuarioActivos();
            public bool IsValid(Usuario u)
            {
                bool resultado = true;

                foreach (var item in misUsuario)
                {
                    if (item.UserName.Equals(u.UserName))
                    {
                        return !resultado;
                    }
                }
                return resultado;
            }
        }
    }
}
