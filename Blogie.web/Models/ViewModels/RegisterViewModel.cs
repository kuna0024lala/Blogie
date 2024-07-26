using System.ComponentModel.DataAnnotations;

namespace Blogie.web.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6,ErrorMessage = "Password has to be atleast 6 character ")]
        public string Password { get; set; }
    }
}
