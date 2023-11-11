using Microsoft.AspNetCore.Mvc;
using DTO.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Web_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

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
        public async Task<IActionResult> Login(Usuario user)
        {
            if (user.email == null || user.contrasena == null)
            {
                ViewBag.Message = "Usuario y/o Password vacíos";
                return View();
            }

            // Llamar al API para autenticar al usuario
            var response = await _httpClient.PostAsJsonAsync("/api/Admin/AuthenticateUser", user);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Usuario y/o Password incorrectos";
                return View();
            }

            var authenticatedUser = await response.Content.ReadFromJsonAsync<AuthenticatedUser>();

            HttpContext.Session.SetString("email", authenticatedUser.email);
            HttpContext.Session.SetString("rol", authenticatedUser.rol);
            HttpContext.Session.SetString("nombre", authenticatedUser.nombre);

            return RedirectToAction("DashboardHome", "Dashboard");
        }
    }

    // Clase para deserializar la respuesta del API
    public class AuthenticatedUser
    {
        public string email { get; set; }
        public string rol { get; set; }
        public string nombre { get; set; }
    }

    //[HttpPost]
    //public IActionResult Login (Usuario user)
    //{
    //    if (user.email == null || user.contrasena == null)
    //    {
    //        ViewBag.Message = "Usuario y/o Password vacios";
    //        return View();
    //    }

    //Usuario userAutenticado = AdminUsuarios.AuthenticateUser(user.email, user.contrasena);

    //if (userAutenticado == null)
    //{
    //    ViewBag.Message = "Usuario y/o Password incorrectos";
    //    return View();
    //}
    //HttpContext.Session.SetString("email", userAutenticado.email);
    //HttpContext.Session.SetString("rol", userAutenticado.rol.nombreRol);
    //HttpContext.Session.SetString("nombre", userAutenticado.nombre);

    //return RedirectToAction("DashboardHome", "Dashboard");
    //        }
}

