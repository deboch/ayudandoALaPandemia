﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ayudandoALaPandemia.Controllers
{
    public class RegistroController : Controller
    {

        [HttpGet]
        public  ActionResult altaUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult altaUsuario(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                RegistroServicios.altaUsuario(u);
                return RedirectToAction("Home/Index");
            }
            return View(u);
        }
    }
}