using App_Logic;

using DTO.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommunicationsController : ControllerBase
    {
        [HttpPost]
        public async Task<API_Response> SendEmail(string subject, string plainTextContent, string emailAddress)
        {
            AdminEmail ae = new AdminEmail();
            await ae.SendEmail(subject, plainTextContent, emailAddress);
            return new API_Response { Result = "OK" };
        }
    }
}
