﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class UserDetailCreateDto
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
