using System.ComponentModel.DataAnnotations;

namespace Hospital.API.DTO.IdentityDTO
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
