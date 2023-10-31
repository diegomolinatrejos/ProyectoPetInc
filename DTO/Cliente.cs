using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Cliente : Usuario
    {
        public List<Mascota> mascotas { get; set; }

        public List<Vale> vales { get; set; }

    }
}
