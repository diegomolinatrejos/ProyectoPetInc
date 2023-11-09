using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_UI.Models;


namespace Web_UI.Controllers
{
    public class LandingPagePetsIncController : Controller
    {

        public IActionResult _LayoutLanding()
        {
            return View();
        }


    }
}