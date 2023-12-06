using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web_UI.Controllers
{
    public class ContrasenaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RecuperarContrasena()
        {
            return View();
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
