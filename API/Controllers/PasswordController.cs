using App_Logic;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[EnableCors("MyCorsPolicy")]
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class PasswordController : Controller
	{
		[HttpPost]
		public async Task<string> CreatePassword(Password password)
		{
			AdminPassword adminPassword = new AdminPassword();

			adminPassword.Create(password);

			return "Ok";

		}

		[HttpGet]
		public async Task<IActionResult> RetrievePasswordByUserId(int id)
		{
			try
			{
				var adminPassword = new AdminPassword();
				var password = adminPassword.RetrieveByUserId(id);
				return Ok(password);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		public async Task<IActionResult> RetrievePasswordByEmail(string email)
		{
			try
			{
				var adminPassword = new AdminPassword();
				var password = adminPassword.RetrieveByEmail(email);
				return Ok(password);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePassword(Password password)
		{
			try
			{
				var adminPassword = new AdminPassword();
				adminPassword.Update(password);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> DeletePassword(Password password)
		{
			try
			{
				var adminPassword = new AdminPassword();
				adminPassword.Delete(password);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetEncryptedPassword(string password)
		{
			try
			{
				var adminPassword = new AdminPassword();
				var encryptedPassword = adminPassword.GetEncryptedPassword(password);
				return Ok(encryptedPassword);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
