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
                // Reemplaza la URL con la URL correcta de tu API
                string apiUrl = "https://petsincqc.azurewebsites.net/api/Admin/AuthenticateUser";

                // Convierte el usuario a formato JSON
                string jsonUser = JsonConvert.SerializeObject(user);

                // Realiza la llamada POST a la API
                var response = await client.PostAsync(apiUrl, new StringContent(jsonUser, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    // Si la autenticación es exitosa, obtén el usuario autenticado
                    var content = await response.Content.ReadAsStringAsync();
                    var userAutenticado = JsonConvert.DeserializeObject<Usuario>(content);

                    HttpContext.Session.SetString("email", userAutenticado.email);
                    HttpContext.Session.SetString("rol", userAutenticado.rol.nombreRol);
                    HttpContext.Session.SetString("nombre", userAutenticado.nombre);

                    return RedirectToAction("DashboardHome", "Dashboard");
                }
                else
                {
                    // Si la autenticación falla, muestra un mensaje de error
                    ViewBag.Message = "Usuario y/o Password incorrectos";
                    return View();
                }
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(Usuario user)
        //{
        //    if (user.email == null || user.contrasena == null)
        //    {
        //        ViewBag.Message = "Usuario y/o Password vacios";
        //        return View();
        //    }

        //    // Llamar al API para autenticar al usuario
        //    var apiResponse = await _apiClient.GetAsync($"api/Admin/AuthenticateUser?email={user.email}&password={user.contrasena}");

        //    if (!apiResponse.IsSuccessStatusCode)
        //    {
        //        ViewBag.Message = "Usuario y/o Password incorrectos";
        //        return View();
        //    }

        //    // Leer el contenido de la respuesta
        //    var responseContent = await apiResponse.Content.ReadAsStringAsync();
        //    var userAutenticado = JsonSerializer.Deserialize<Usuario>(responseContent);

        //    HttpContext.Session.SetString("email", userAutenticado.email);
        //    HttpContext.Session.SetString("rol", userAutenticado.rol.nombreRol);
        //    HttpContext.Session.SetString("nombre", userAutenticado.nombre);

        //    return RedirectToAction("DashboardHome", "Dashboard");
        //}


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
}

