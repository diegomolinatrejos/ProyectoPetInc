﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class API_Response
    {
        public string Message { get; set; }
        public string Result { get; set; }
        public object Data { get; set; }
    }
}
