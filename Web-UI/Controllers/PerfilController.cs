using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult VistaPerfil()
        {
            return View();
        }


        public IActionResult EdicionPerfil()
        {
            return View();
        }

        public IActionResult CambioContrasena()
        {
            return View();
        }
    }
}
