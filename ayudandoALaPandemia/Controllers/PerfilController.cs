using ayudandoALaPandemia.Builder;
using ayudandoALaPandemia.Utilities;
using ayudandoALaPandemia.ViewModels;
using System.IO;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ayudandoALaPandemia.Controllers
{
    public class PerfilController : BaseController
    {
        [HttpGet]
        public ActionResult Index(Usuarios user)
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult MisDenuncias(Usuarios user)
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int userId = (int)Session["id"];
            List<Denuncias> misDenuncias = necesidadesServicios.ObtenerDenunciasPorUserId(userId);
            ViewBag.MisDenuncias = misDenuncias;
            return View();

        }

        [HttpGet]
        public ActionResult MisDonaciones()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int userId = (int)Session["id"];
            ViewBag.UserId = userId;
            return View();
        }

        [HttpGet]
        public ActionResult Editar()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int userId = (int)Session["id"];
            Usuarios usuario = registroServicios.ObtenerPorId(userId);
            UsuarioDto usuarioDto = new UsuarioDto();
            usuarioDto.username = usuario.UserName;
            usuarioDto.email = usuario.Email;
            usuarioDto.idUsuario = usuario.IdUsuario;
            usuarioDto.nombre = usuario.Nombre;
            usuarioDto.apellido = usuario.Apellido;
            usuarioDto.fechaNacimiento = usuario.FechaNacimiento;
            usuarioDto.foto = usuario.Foto;
            usuarioDto.password = usuario.Password;
            ViewBag.usuarioDto = usuarioDto;
            return View(usuarioDto);
        }

        [HttpPost]
        public ActionResult Editar(UsuarioDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                    if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                    {
                        //TODO: Agregar validacion para confirmar que el archivo es una imagen
                        //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                        string nombreSignificativo = usuarioDto.NombreSignificativoImagen;
                        //Guardar Imagen
                        string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                        usuarioDto.foto = pathRelativoImagen;
                    }

                    int userId = (int)Session["id"];
                    usuarioDto.idUsuario = userId;
                    UsuarioBuilder builder = new UsuarioBuilder();
                    Usuarios usuarioModificado = builder.toUsuariosEntity(usuarioDto);
                    Usuarios usuarioModificado2 = registroServicios.Modificar(usuarioModificado);

                    Session["id"] = usuarioModificado2.IdUsuario;
                    Session["username"] = usuarioModificado2.UserName;
                    Session["nombre"] = usuarioModificado2.Nombre;
                    Session["apellido"] = usuarioModificado2.Apellido;
                    Session["fechaNacimiento"] = usuarioModificado2.FechaNacimiento;
                    Session["email"] = usuarioModificado2.Email;
                    Session["tipo"] = usuarioModificado2.TipoUsuario;
                    Session["foto"] = usuarioModificado2.Foto;
                   
                    TempData["exitoPerfil"] = "Guardaste con exito!!";
                    return RedirectToAction("Index", "Perfil");
                
            }
            ViewBag.usuarioDto = usuarioDto;
            return View();
            
        }

        [HttpGet]
        public ActionResult MisNecesidades()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int userId = (int)Session["id"];
            bool estado = true;
            List<Necesidades> misNecesidadesActivas = necesidadesServicios.ObtenerNecesidadesSegunActivacion(estado, userId);
            ViewBag.misNecesidades = misNecesidadesActivas;
            return View();
        }
    }
}