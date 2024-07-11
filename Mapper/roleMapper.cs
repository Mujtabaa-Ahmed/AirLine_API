using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Role;
using api.DTOs.UserDTO;
using api.Models;

namespace api.Mapper
{
    public static class roleMapper
    {
        public static roleDTO ToroleDTO(this class_roles role)
        {
            return new roleDTO
            {
                r_id = role.r_id,
                r_name = role.r_name
            };
        }
        public static class_roles ToCreateRoleDTO(this createRoleDTO rDTO)
        {
            return new class_roles
            {
                r_name = rDTO.r_name
            };
        }
    }
}