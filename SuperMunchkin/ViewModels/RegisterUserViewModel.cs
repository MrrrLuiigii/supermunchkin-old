using System.ComponentModel.DataAnnotations;

namespace SuperMunchkin.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordCheck { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }
    }
}
