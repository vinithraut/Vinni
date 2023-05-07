﻿using System.ComponentModel.DataAnnotations;

namespace VinniDatingApp.DTOs
{
    public class RegisterDTO
    {
        [Required]        
        public string username { get; set; }

        [Required]
        [StringLength(8, MinimumLength =4)]
        public string password { get; set; }
    }
}
