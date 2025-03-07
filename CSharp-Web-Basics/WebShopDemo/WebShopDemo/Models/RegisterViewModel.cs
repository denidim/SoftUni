﻿using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; } = null!;

        [Required]
        [StringLength(20,MinimumLength =2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20,MinimumLength =2)]
        public string LastName { get; set; } = null!;
    }
}
