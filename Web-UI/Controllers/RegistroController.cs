﻿using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult RegistroServicios()
        {
            return View();
        }

        public IActionResult RegistroUsuario()
        {
            return View();
        }

        public IActionResult RegistroMascotas()
        {
            return View();
        }


        public IActionResult Cancelar()
        {
            return View();
        }
    }// fin de la clase

}// fin de namespace
