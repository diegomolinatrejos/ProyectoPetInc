using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_UI.Models;


namespace Web_UI.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult DashboardHome()
        {
            return View();
        }

    }
}