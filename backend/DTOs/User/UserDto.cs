using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DTOs.User
{
    public class UserDTO
    {
        [Required]
        public string ? UserName { get; set; }
        [Required]
        public string ? Password { get; set; }
        [Required]
        [EmailAddress]
        public string ? Email { get; set; }
    }
}