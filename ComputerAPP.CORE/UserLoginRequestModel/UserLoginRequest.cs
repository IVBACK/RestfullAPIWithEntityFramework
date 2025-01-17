﻿using System.ComponentModel.DataAnnotations;

namespace ComputerAPP.CORE.Models
{
    public class UserLoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
