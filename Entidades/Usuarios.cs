using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Usuarios
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime fechaNacimiento { get; set; } 
        [Required(ErrorMessage ="Por favor, elegir nombre para su usuario")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage ="Ingrese un mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Por favor ingrese su clave")]
        [Range(8,30, ErrorMessage ="Su clave debe ser mayor a 8 y menor a 30")]
        public string Password { get; set; }
        public string ConfirmPass { get; set; }

        public string TipoUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
        public bool Activo { get; set; }
        public string Token { get; set; }

        public Usuarios(int id, string nombre, string apellido, DateTime fechaNacimiento, string userName, string email, string password, string tipoUsuario, DateTime fechaCreacion, bool activo, string token)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            fechaNacimiento = fechaNacimiento;
            Username = userName;
            Email = email;
            Password = password;
            TipoUsuario = tipoUsuario;
            fechaCreacion = fechaCreacion;
            Activo = activo;
            Token = token;
        }

  
        public class existeUsuario : ValidationAttribute
        {
            List<Usuarios> misUsuarios = RegistroServicios.traerTodosLosUsuariosActivos();
            public bool IsValid(Usuarios u)
            {
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