using System;
using System.Threading.Tasks;
using System.Windows;

namespace backend.DTOs.User
{
    public class NewUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Tokens { get; set; }

    }
}