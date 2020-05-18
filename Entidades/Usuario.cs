using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades 
{ 
    public class Usuario
    {
	
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime fechaNacimiento { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string TipoUsuario { get; set; }
            public DateTime fechaCreacion { get; set; }
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
    }
}
