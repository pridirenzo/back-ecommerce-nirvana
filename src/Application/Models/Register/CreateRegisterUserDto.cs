﻿using System.ComponentModel.DataAnnotations;

namespace Application.Models.Register
{
    public class CreateRegisterUserDto
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(64, ErrorMessage = "First name cannot be longer than 64 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(64, ErrorMessage = "Last name cannot be longer than 64 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(128, ErrorMessage = "Email cannot be longer than 128 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Password cannot be longer than 255 characters")]
        public string Password { get; set; }
    }
}
