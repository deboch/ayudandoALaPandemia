using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayudandoALaPandemia.Builder;
using ayudandoALaPandemia.Utilities;
using ayudandoALaPandemia.ViewModels;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class NecesidadController : BaseController
    {
        // GET: NecesidadAction
        public ActionResult Index()
        {
            try
            {
                List<Necesidades> necesidades = necesidadesServicios.GetNecesidades();
                ViewBag.Necesidades = necesidades;
                return View();
            }
            catch
            {
                return null;
            }
        }

        // necesidad/{id}/detalle
        [HttpGet]
        public ActionResult Detalle()
        {
            int userId = (int)Session["id"];
            int idNecesidad = Int32.Parse(Request.Url.Segments[2].Remove(Request.Url.Segments[2].Length - 1));
            Necesidades necesidad = necesidadesServicios.ObtenerPorId(idNecesidad);
            Usuarios usuario = registroServicios.ObtenerPorId(userId);
            NecesidadesValoraciones valoracion = necesidadesServicios.ObtenerValoracionPorUsuarioNecesidad(usuario.IdUsuario, necesidad.IdNecesidad);
            NecesidadBuilder builder = new NecesidadBuilder();
            NecesidadDto necesidadDto = builder.necesidadDtoParaDetalle(necesidad, usuario, valoracion);
            ViewBag.Necesidad = necesidadDto;
            return View();
        }

        [HttpGet]
        public ActionResult donacionMonetaria()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int idNecesidad = Int32.Parse(Request.Url.Segments[2].Remove(Request.Url.Segments[2].Length - 1));
            NecesidadesDonacionesMonetarias donacion = donacionesMonetariasServicios.ObtenerPorNecesidadId(idNecesidad);
            decimal donacionesMonetarias = donacionesMonetariasServicios.ObtenerTodasLasDonaciones(donacion);
            ViewBag.TotalRestante = donacionesMonetarias;
            ViewBag.Total = donacion.Dinero;
            ViewBag.IdNecesidadMonetaria = donacion.IdNecesidadDonacionMonetaria;
            ViewBag.userId = (int)Session["id"];
            return View();
        }

        [HttpGet]
        public ActionResult donacionInsumos()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            int idNecesidad = Int32.Parse(Request.Url.Segments[2].Remove(Request.Url.Segments[2].Length - 1));
            List<NecesidadesDonacionesInsumos> donacion = donacionesInsumosServicios.ObtenerPorNecesidadId(idNecesidad);
            int cant = donacion.Count;
            NecesidadDto model = new NecesidadDto();

            for (int i = 0; i < cant; i++)
            {
                InsumosDto insumoDto = new InsumosDto();
                model.insumos.Add(insumoDto);
            }
            
            ViewBag.Cantidades = donacionesInsumosServicios.obtenerCantidadesRestantes(donacion);
            ViewBag.TotalInsumos = donacion;
            ViewBag.userId = (int)Session["id"];

            return View(model);
        }


        [HttpPost]
        public ActionResult donacionMonetaria(DonacionesMonetarias donacionesMonetarias)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                string nombreSignificativo = donacionesMonetarias.ArchivoTransferencia;
                //Guardar Imagen
                string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                donacionesMonetarias.ArchivoTransferencia = pathRelativoImagen;
            }
            necesidadesServicios.donacionMonetaria(donacionesMonetarias);
            TempData["exito"] = "Donaste con exito!!";
            return RedirectToAction("Index", "Necesidades");
        }

        [HttpPost]
        public ActionResult donacionInsumos(NecesidadDto necesidadDto)
        {
            NecesidadBuilder builder = new NecesidadBuilder();
            List<DonacionesInsumos> lista = builder.transformarADonacionesInsumos(necesidadDto);
            necesidadesServicios.donacionInsumo(lista);
            TempData["exito"] = "Donaste con exito!!";
            return RedirectToAction("Index", "Necesidades");
        }

        [HttpPost]
        public int Eliminar(int id)
        {
            return necesidadesServicios.Borrar(id);
        }

        [HttpGet]
        public ActionResult Modificar()
        {
            int idNecesidad = Int32.Parse(Request.Url.Segments[2].Remove(Request.Url.Segments[2].Length - 1));
            Necesidades necesidad = necesidadesServicios.ObtenerPorId(idNecesidad);
            NecesidadBuilder builder = new NecesidadBuilder();
            NecesidadDto necesidadDto = builder.trasnformarNecesidadANecesidadDto(necesidad);

            ViewBag.necesidadDto = necesidadDto;
            return View(necesidadDto);
        }
        
        [HttpPost]
        public ActionResult Modificar(NecesidadDto necesidadDto)
        {
            int userId = (int)Session["id"];
            NecesidadBuilder builder = new NecesidadBuilder();
            
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                string nombreSignificativo = necesidadDto.NombreSignificativoImagen;
                //Guardar Imagen
                string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                necesidadDto.foto = pathRelativoImagen;
            }

            if (!ModelState.IsValid)
                return View(necesidadDto);

            Necesidades necesidad = builder.toNecesidadesEntity(necesidadDto, userId);
            necesidadesServicios.Modificar(necesidad);
            return RedirectToAction("MisNecesidades", "Perfil");
        }

        [HttpGet]
        public ActionResult Denuncia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Denuncia(DenunciaDto denunciaDto)
        {
            int userId = (int)Session["id"];
            DenunciaBuilder builder = new DenunciaBuilder();
            Denuncias nuevaDenuncia = builder.toDenunciasEntity(denunciaDto, userId);
            necesidadesServicios.CrearDenuncia(nuevaDenuncia);

            
            TempData["exito"] = "La denuncia se ha hecho correctamente!";
            return RedirectToAction("Index", "Necesidades");
        }

    }
}