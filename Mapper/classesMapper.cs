using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Classes;
using api.Models;

namespace api.Mapper
{
    public static class classesMapper
    {
        public static classesDTO ToClassesDTO(this class_classes classes)
        {
            return new classesDTO 
            {
                c_id = classes.c_id,
                c_name = classes.c_name,
                c_price = classes.c_price
            };
        }
        public static class_classes ToCreateClassDTO(this createClassesDTO cDTO)
        {
            return new class_classes
            {
                c_name = cDTO.c_name,
                c_price = cDTO.c_price
            };
        }
    }
}