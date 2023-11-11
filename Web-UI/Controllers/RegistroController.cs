using Microsoft.AspNetCore.Mvc;

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


        public IActionResult Register()
        {
            return RedirectToAction("Login", "Login");

        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");

         }
    }

}
