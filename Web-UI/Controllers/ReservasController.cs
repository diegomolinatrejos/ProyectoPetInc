using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class ReservasController : Controller
    {
        public IActionResult GestionarReservasCliente()
        {
            return View();
        }

        public IActionResult GestionarReservasGestor()
        {
            return View();
        }

        public IActionResult RealizarReservaGestor()
        {
            return View();
        }

        public IActionResult RealizarReserva()
        {
            return View();
        }
    }
}
