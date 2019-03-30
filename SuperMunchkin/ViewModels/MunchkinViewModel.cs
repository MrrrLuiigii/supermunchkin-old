﻿using System.ComponentModel.DataAnnotations;

namespace SuperMunchkin.ViewModels
{
    public enum MunchkinGender
    {
        Male,
        Female
    }

    public class MunchkinViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public MunchkinGender Gender { get; set; }
    }
}
