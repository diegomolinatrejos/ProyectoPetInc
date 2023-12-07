using Microsoft.AspNetCore.Mvc;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using DTO.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


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

        public IActionResult RecuperarContrasena()
        {
            return View();
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

            using (HttpClient client = new HttpClient())
            {
                // Reemplaza la URL con la URL correcta de tu API y método de autenticación
                //string apiUrl = "https://petsincapiqc.azurewebsites.net/api/Admin/GetUsuarioPorFrase?searchPhrase=" + user.email;
                string apiUrl = "http://localhost:5087/api/Admin/GetUsuarioPorFrase?searchPhrase=" + user.email;

                // Realiza la llamada GET al API para obtener el usuario por email
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Si la llamada es exitosa, verifica la contraseña
                    var content = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);

                    var userAutenticado = usuarios.FirstOrDefault(u => u.contrasena == user.contrasena);

                    if (userAutenticado != null)
                    {
                        // Si la autenticación es exitosa, establece las sesiones y redirige
                        HttpContext.Session.SetString("email", userAutenticado.email);
                        HttpContext.Session.SetString("rol", userAutenticado.rol.nombreRol);
                        HttpContext.Session.SetString("nombre", userAutenticado.nombre);
                        HttpContext.Session.SetInt32("Id", userAutenticado.Id);

                        return RedirectToAction("DashboardHome", "Dashboard");
                    }
                }

                // Si la autenticación falla, muestra un mensaje de error
                ViewBag.Message = "Usuario y/o Password incorrectos";
                return View();
            }
        }

        

        [HttpPost]
        public async Task<IActionResult> RecuperarContrasena(Usuario usuario)
        {
            if (usuario.email == null)
            {
                ViewBag.Message = "Correo electrónico está vacío";
                return View();
            }

            using (HttpClient client = new HttpClient())
            {
                // Reemplaza la URL con la URL correcta de tu API y método de autenticación
                //string apiUrl = "https://petsincapiqc.azurewebsites.net/api/Admin/GetUsuarioPorFrase?searchPhrase=" + user.email;
                string apiUrl = "http://localhost:5087/api/Admin/GetUsuarioPorFrase?searchPhrase=" + usuario.email;

                // Realiza la llamada GET al API para obtener el usuario por email
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Si la llamada es exitosa, verifica el correo electronico
                    var content = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);

                    var userAutenticado = usuarios.FirstOrDefault(u => u.email == usuario.email);

                    if (userAutenticado != null)
                    {
                        // Si la autenticación es exitosa, establece las sesiones y redirige
                        await RecuperarContrasena(usuario);

                        return RedirectToAction("DashboardHome", "Dashboard");//deberia de redirigirse a la pantalla para cambiar contraseña
                    }
                }

                // Si la autenticación falla, muestra un mensaje de error
                ViewBag.Message = "Correo electrónico incorrecto";
                return View();
            }
        }
    }

 }


