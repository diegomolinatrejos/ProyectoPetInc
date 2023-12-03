using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Logic.Admins;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        [HttpGet]
        public List<Mascota> GetMascotas()
        {
            AdminMascotas adminMascotas = new AdminMascotas();

            return adminMascotas.GetAllMascotas();
        }

        [HttpPost]
        public string CreateMascota(Mascota mascota)
        {
            AdminMascotas adminMascotas = new AdminMascotas();

            adminMascotas.CreateMascota(mascota);

            return "OK";
        }

        [HttpGet]
        public Mascota GetMascotaPorId(int id)
        {
            AdminMascotas adminMascotas = new AdminMascotas();
            return adminMascotas.GetMascotaById(id);
        }

        [HttpGet]
        public List<Mascota> GetMascotaPorIdDelDuenno(int idDuenno)
        {
            AdminMascotas adminMascotas = new AdminMascotas();
            return adminMascotas.GetMascotaByPhrase(idDuenno);
        }

        [HttpPut]
        public string UpdateMascota(Mascota mascota)
        {
            AdminMascotas adminMascotas = new AdminMascotas();
            adminMascotas.UpdateMascota(mascota);
            return "Mascota Actualizada";
        }

        [HttpDelete]
        public string DeleteMascota(int id)
        {
            AdminMascotas adminMascotas = new AdminMascotas();
            adminMascotas.DeleteMascotaById(id);
            return "Mascota eliminada";
        }
    }
}