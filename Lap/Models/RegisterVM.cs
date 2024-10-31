﻿using System.ComponentModel.DataAnnotations;

namespace Lap.Models
{
    public class RegisterVM
    {
        [Display(Name = "Username")]
        public required string UserName { get; set; }
        public required string FullName { get; set; }
        [Phone(ErrorMessage = "Phone not valid")]

        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Display(Name = "Comfirm password")]
        [Compare("Password", ErrorMessage = "The password and comfirm password does not match")]
        [DataType(DataType.Password)]
        public required string ComfirmPassword { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}
