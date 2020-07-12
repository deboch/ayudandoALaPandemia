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
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int userId = (int)Session["id"];
            int idNecesidad = Int32.Parse(Request.Url.Segments[2].Remove(Request.Url.Segments[2].Length - 1));
            Necesidades necesidad = necesidadesServicios.ObtenerPorId(idNecesidad);
            Usuarios usuario = registroServicios.ObtenerPorId(userId);
            NecesidadesValoraciones valoracion = necesidadesServicios.ObtenerValoracionPorUsuarioNecesidad(usuario.IdUsuario, necesidad.IdNecesidad);
            int totalDeMegusta = necesidadesServicios.ObtenerSumaTotalDeValoraciones(idNecesidad);
            NecesidadBuilder builder = new NecesidadBuilder();
            NecesidadDto necesidadDto = builder.necesidadDtoParaDetalle(necesidad, usuario, valoracion);

            ViewBag.TotalDeMeGusta = totalDeMegusta;
            decimal cant;

            if(necesidadDto.tipoDonacion == "Insumo") { 
                List<NecesidadesDonacionesInsumos> donacion = donacionesInsumosServicios.ObtenerPorNecesidadId(idNecesidad);

                foreach (var p in donacion)
                {
                    InsumosDto insumosDto = new InsumosDto();
                    int totalDonado = donacionesInsumosServicios.ObtenerTotales(p.IdNecesidadDonacionInsumo);
                    insumosDto.cantidad = p.Cantidad;
                    insumosDto.nombre = p.Nombre;
                    insumosDto.cantidadDonada = totalDonado;
                    insumosDto.finalizada = p.Cantidad - totalDonado;
                    necesidadDto.insumos.Add(insumosDto);
                }
            }
            else
            {
                NecesidadesDonacionesMonetarias donacion = donacionesMonetariasServicios.ObtenerPorNecesidadId(idNecesidad);
                decimal donacionesMonetarias = donacionesMonetariasServicios.ObtenerTodasLasDonaciones(donacion);
                cant = donacionesMonetarias;
                ViewBag.Total = cant;
            }
            
            ViewBag.Necesidad = necesidadDto;

            return View(necesidadDto);
        }

        [HttpGet]
        public ActionResult donacionMonetaria()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            DonacionMonetariaDto donacionMonetariaDto = new DonacionMonetariaDto();
            int idNecesidad = Int32.Parse(Request.Url.Segments[2].Remove(Request.Url.Segments[2].Length - 1));
            NecesidadesDonacionesMonetarias donacion = donacionesMonetariasServicios.ObtenerPorNecesidadId(idNecesidad);
            decimal donacionesMonetarias = donacionesMonetariasServicios.ObtenerTodasLasDonaciones(donacion);
            donacionMonetariaDto.totalRestante = donacion.Dinero - donacionesMonetarias;
            donacionMonetariaDto.totalDeDinero = donacion.Dinero;
            donacionMonetariaDto.IdNecesidadDonacionMonetaria = donacion.IdNecesidadDonacionMonetaria;
            donacionMonetariaDto.IdUsuario = (int)Session["id"];
            return View(donacionMonetariaDto);
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
            // int cant = donacion.Count;
            NecesidadDto model = new NecesidadDto();
            ViewBag.Cantidades = donacionesInsumosServicios.obtenerCantidadesRestantes(donacion);

            foreach (var p in donacion)
            {
                InsumosDto insumoDto = new InsumosDto();
                insumoDto.cantidad = ViewBag.Cantidades[p.Nombre];
                model.insumos.Add(insumoDto);
            }
            
            ViewBag.TotalInsumos = donacion;
            ViewBag.userId = (int)Session["id"];

            return View(model);
        }


        [HttpPost]
        public ActionResult donacionMonetaria(DonacionMonetariaDto donacionMonetariaDto)
        {
            if (!ModelState.IsValid)
            {
                return View(donacionMonetariaDto);
            }
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                string nombreSignificativo = donacionMonetariaDto.comprobante;
                //Guardar Imagen
                string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                donacionMonetariaDto.comprobante = pathRelativoImagen;
            }
            DonacionMonetariaBuilder builder = new DonacionMonetariaBuilder();
            DonacionesMonetarias donacionMonetaria = builder.dtoAEntidad(donacionMonetariaDto);
            necesidadesServicios.donacionMonetaria(donacionMonetaria);
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
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
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
        public ActionResult Denunciar()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int userId = (int)Session["id"];
            List<MotivoDenuncia> lista = denunciasServicio.obtenerTodosLosMotivos();
            
            ViewBag.Motivos = denunciasServicio.obtenerTodosLosMotivos().Select(v => new SelectListItem()
            {
                Text = v.Descripcion,
                Value = v.IdMotivoDenuncia.ToString()
            });

            DenunciaNecesidadDto denunciaDto = new DenunciaNecesidadDto();
            denunciaDto.usuarioId = userId;
            return View(denunciaDto);
        }

        [HttpPost]
        public ActionResult Denunciar(DenunciaNecesidadDto denunciaDto)
        {
            if (!ModelState.IsValid)
            {
                return View(denunciaDto);
            }

            int idNecesidad = Int32.Parse(Request.Url.Segments[2].Remove(Request.Url.Segments[2].Length - 1));
            denunciaDto.necesidadId = idNecesidad;
            DenunciaBuilder builder = new DenunciaBuilder();
            Denuncias nuevaDenuncia = builder.toDenunciasEntity(denunciaDto);
            necesidadesServicios.CrearDenuncia(nuevaDenuncia);
            
            TempData["exito"] = "La denuncia se ha hecho correctamente!";
            return RedirectToAction("Index", "Necesidades");
        }

    }
}