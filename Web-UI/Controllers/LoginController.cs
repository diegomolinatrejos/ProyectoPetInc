using Microsoft.AspNetCore.Mvc;
using DTO.Models;
using App_Logic.Admins;

namespace Web_UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login (Usuario user)
        {
            if (user.email == null || user.contrasena == null)
            {
                ViewBag.Message = "Usuario y/o Password vacios";
                return View();
            }
            Usuario userAutenticado = AdminUsuarios.AuthenticateUser(user.email, user.contrasena);
            if (userAutenticado == null)
            {
                ViewBag.Message = "Usuario y/o Password incorrectos";
                return View();
            }
            HttpContext.Session.SetString("email", userAutenticado.email);
            HttpContext.Session.SetString("rol", userAutenticado.rol.nombreRol);
            HttpContext.Session.SetString("nombre", userAutenticado.nombre);

            return RedirectToAction("DashboardHome", "Dashboard");
        }
    }
}
