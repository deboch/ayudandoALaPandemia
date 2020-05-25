using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        [Required(ErrorMessage = "Por favor, elegir nombre para su usuario")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Ingrese un mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su clave")]
        [Range(8, 30, ErrorMessage = "Su clave debe ser mayor a 8 y menor a 30")]
        public string Password { get; set; }
        public string ConfirmPass { get; set; }

        public string TipoUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
        public bool Activo { get; set; }
        public string Token { get; set; }

        public Usuario(int id, string nombre, string apellido, DateTime fNacimiento, string userName, string email, string password, string tipoUsuario, DateTime fCreacion, bool activo, string token)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            fechaNacimiento = fNacimiento;
            Username = userName;
            Email = email;
            Password = password;
            TipoUsuario = tipoUsuario;
            fechaCreacion = fCreacion;
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