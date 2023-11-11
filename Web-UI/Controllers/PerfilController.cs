using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult VistaPerfil()
        {
            return View();
        }
    }
}
