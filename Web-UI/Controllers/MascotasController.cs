using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class MascotasController : Controller
    {

        public IActionResult RegistroMascotas()
        {
            return View();
        }
        public IActionResult EdicionMascotas()
        {
            return View();
        }

        public IActionResult MisMascotas()
        {
            return View();
        }
    }
}
