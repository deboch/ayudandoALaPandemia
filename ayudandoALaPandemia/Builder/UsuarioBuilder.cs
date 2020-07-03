using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayudandoALaPandemia.ViewModels;
using Repositorios;

namespace ayudandoALaPandemia.Builder
{
    public class UsuarioBuilder
    {
        public Usuarios toUsuariosEntity(UsuarioDto usuarioDto)
        {
            Usuarios usuarioModificado = new Usuarios();
            usuarioModificado.IdUsuario = usuarioDto.idUsuario;
            usuarioModificado.Nombre = usuarioDto.nombre;
            usuarioModificado.Apellido = usuarioDto.apellido;
            usuarioModificado.FechaNacimiento = usuarioDto.fechaNacimiento;
            usuarioModificado.Foto = usuarioDto.foto;

            return usuarioModificado;
        }
    }
}