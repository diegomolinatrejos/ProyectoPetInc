using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult ReportesAdm()
        {
            return View();
        }

        public IActionResult GraficaDispositivo()
        {
            return View();
        }
    }
}
