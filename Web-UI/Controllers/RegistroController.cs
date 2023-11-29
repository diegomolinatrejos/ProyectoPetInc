using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web_UI.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegistroMascotas()
        {
            return View();
        }

        public IActionResult Cancelar()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Registrar()
        {
            return RedirectToAction("Index", "Home");
        }

    }// fin de la clase

}
