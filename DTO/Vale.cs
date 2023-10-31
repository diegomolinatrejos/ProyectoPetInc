using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Vale : BaseClass
    {
        public Cliente cliente { get; set; }
        public decimal monto { get; set; }
    }
}
