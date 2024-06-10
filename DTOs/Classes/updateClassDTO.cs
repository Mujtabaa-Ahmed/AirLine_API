using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Classes
{
    public class updateClassDTO
    {
        public string c_name { get; set; } = string.Empty;
        public int c_price { get; set; }
    }
}