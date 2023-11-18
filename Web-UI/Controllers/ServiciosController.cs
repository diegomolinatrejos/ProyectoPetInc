using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult RegistroServicios()
        {
            return View();
        }

        public IActionResult ServiciosActuales()
        {
            return View();
        }


        public IActionResult EdicionServicios()
        {
            return View();
        }
    }
}
