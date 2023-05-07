using System.ComponentModel.DataAnnotations;

namespace VinniDatingApp.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
