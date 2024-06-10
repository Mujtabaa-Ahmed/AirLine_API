using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Classes
{
    public class classesDTO
    {
         public int c_id { get; set; }
        public string c_name { get; set; } = string.Empty;
        public int c_price { get; set; }
    }
}