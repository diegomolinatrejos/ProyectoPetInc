using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class Password : BaseClass
	{
		public int idUsuario { get; set; }
		public string newPassword { get; set; }
	}
}
