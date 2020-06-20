﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class NecesidadController : BaseController
    {
        // GET: NecesidadAction
        public ActionResult Index()
        {
            return View();
        }

        // necesidad/{id}/detalle
        [HttpGet]
        public ActionResult Detalle()
        {
            int idNecesidad = Int32.Parse(Request.Url.Segments[2].Remove(Request.Url.Segments[2].Length - 1));
            Necesidades necesidad = necesidadesServicios.ObtenerPorId(idNecesidad);
            ViewBag.Necesidad = necesidad;
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
            ViewBag.Cantidades = donacionesInsumosServicios.obtenerCantidadesRestantes(donacion);
            ViewBag.TotalInsumos = donacion;
            return View();
        }


        [HttpPost]
        public ActionResult donacionMonetaria(DonacionesMonetarias donacionesMonetarias)
        {
            necesidadesServicios.donacionMonetaria(donacionesMonetarias);
            TempData["exito"] = "Donaste con exito!!";
            return RedirectToAction("Index", "Necesidades");
        }

        [HttpPost]
        public ActionResult donacionInsumos(DonacionesInsumos donacionesInsumos)
        {
            necesidadesServicios.donacionInsumo(donacionesInsumos);
            TempData["exito"] = "Donaste con exito!!";
            return RedirectToAction("Index", "Necesidades");
        }

        [HttpPost]
        public int Eliminar(int id)
        {
            return necesidadesServicios.Borrar(id);
        }

        [HttpPost]
        public Necesidades Modificar(Necesidades necesidad)
        {
            return necesidadesServicios.Modificar(necesidad);
        }

    }
}