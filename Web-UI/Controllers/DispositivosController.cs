using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class DispositivosController : Controller
    {
        public IActionResult RegistrarDispositivo()
        {
            return View();
        }


        public IActionResult DispositivosActuales()
        {
            return View();
        }


        public IActionResult EdicionDispositivos()
        {
            return View();
        }
    }
}
