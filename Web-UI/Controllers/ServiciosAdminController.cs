using Microsoft.AspNetCore.Mvc;

namespace Web_UI.Controllers
{
    public class ServiciosAdminController : Controller
    {
        public IActionResult DashBoardAdmin()
        {
            return View();
        }

        public IActionResult ServiciosAdminList()
        {
            return View();
        }
    }
}
