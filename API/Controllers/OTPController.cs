using App_Logic;
using App_Logic.Admins;
using DTO;
using DTO.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;


namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OTPController : Controller
    {
        [HttpPost]
        public async Task<string> CreateOTP(CreateOtpDto otp)
        {
            AdminOTP adminOTP = new AdminOTP();

            await adminOTP.CreateOTP(otp);

            return "Ok";

        }



    }
}
