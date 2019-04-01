using System.ComponentModel.DataAnnotations;

namespace SuperMunchkin.ViewModels
{
    public enum MunchkinGender
    {
        Male = 1,
        Female = 2
    }

    public class MunchkinViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public MunchkinGender? Gender { get; set; }
    }
}
