using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class ConfiguracionController : Controller
    {
        public IActionResult ConfiguracionInicial()
        {
            return View();
        }
    }
}
