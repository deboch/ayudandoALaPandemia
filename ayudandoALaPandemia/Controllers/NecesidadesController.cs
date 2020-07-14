using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ayudandoALaPandemia.Builder;
using ayudandoALaPandemia.Utilities;
using ayudandoALaPandemia.ViewModels;
using Newtonsoft.Json;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class NecesidadesController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string keyword)
        {
            if (Session["email"] != null)
            {
                int userId = (int)Session["id"];
                List<Necesidades> misNecesidades = necesidadesServicios.ObtenerPorUserId(userId);
                ViewBag.misNecesidades = misNecesidades.Count > 0 ? misNecesidades : null;

                if (keyword != null)
                {
                    List<Necesidades> necesidadesBuscadas = searchServicios.ObtenerNecesidades(userId, keyword);
                    ViewBag.otrasNecesidades = necesidadesBuscadas.Count > 0 ? necesidadesBuscadas : null;
                }
                else
                {
                    List<Necesidades> otrasNecesidades = necesidadesServicios.ObtenerTodasMenosPorUserId(userId);
                    ViewBag.otrasNecesidades = otrasNecesidades.Count > 0 ? otrasNecesidades : null;
                    return View();
                }
            }


            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: Necesidades
        [HttpGet]
        public ActionResult Home(string keyword)
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index");
            }
            NecesidadDto model = new NecesidadDto();
            InsumosDto insumoDto = new InsumosDto();
            model.insumos.Add(insumoDto);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Crear(NecesidadDto necesidadDto)
        {
            int userId = (int)Session["id"];
            NecesidadBuilder builder = new NecesidadBuilder();

            if (!ModelState.IsValid)
                return View(necesidadDto);

            Dictionary<string, string> validaciones = necesidadesServicios.ObtenerValidaciones(userId);
            Dictionary<string, string> validacionesNecesidadDto = builder.validarNecesidadDto(necesidadDto);

            if (validaciones.Count != 0 || validacionesNecesidadDto.Count != 0)
            {
                ViewBag.ValidacionesDeUsuario = validaciones;
                ViewBag.ValidacionesNecesidadDto = validacionesNecesidadDto;
                return View(necesidadDto);
            }

            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                string nombreSignificativo = necesidadDto.NombreSignificativoImagen;
                //Guardar Imagen
                string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                necesidadDto.foto = pathRelativoImagen;
            }

            Necesidades nuevaNecesidad = builder.toNecesidadesEntity(necesidadDto, userId);
            necesidadesServicios.Crear(nuevaNecesidad);
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public bool Valorar(int like, int idNecesidad)
        {
            var userId = (int)Session["id"];
            return necesidadesServicios.Valorar(like, userId, idNecesidad);
        }

        [HttpPost]
        public string ActualizarEstado(bool isActive)
        {
            var userId = (int)Session["id"];
            List<Necesidades> necesidades = necesidadesServicios.ObtenerNecesidadesSegunActivacion(isActive, userId);
            return JsonConvert.SerializeObject(necesidades, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

    }
}
