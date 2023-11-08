using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_UI.Models;


namespace Web_UI.Controllers
{
    public class LandingPagePetsIncController : Controller
    {
        private readonly ILogger<LandingPagePetsIncController> _logger;

        public LandingPagePetsIncController(ILogger<LandingPagePetsIncController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Device()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

    }
}