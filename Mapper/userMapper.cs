using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.User;
using api.DTOs.UserDTO;
using api.Models;

namespace api.Mapper
{
    public static class userMapper
    {
        public static userDTO ToUserDTO(this class_users user)
        {
            return new userDTO 
            {
                u_id = user.u_id,
                u_name = user.u_name,
                u_mail = user.u_mail,
                r_id = user.r_id,
                u_pass = "Protected"
            };
        }

        public static class_users ToCreateUserDTO(this createUserDTO uDTO)
        {
            return new class_users 
            {
                u_name = uDTO.u_name,
                u_mail = uDTO.u_mail,
                u_pass = uDTO.u_pass,
                r_id = uDTO.r_id
            };
        }
    }
}