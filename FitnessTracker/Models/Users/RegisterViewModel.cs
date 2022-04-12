using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Users
{
    public class RegisterViewModel
    {
        [Display(Name = "Full Name")]
        [StringLength(UserFullNameMaxLength, MinimumLength = UserFullNameMinLength,
            ErrorMessage = "The full name must be between {2} and {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(UserPasswordMaxLength, MinimumLength = UserPasswordMinLength,
            ErrorMessage = "The password must be between {2} and {1} characters long.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password must be equal.")]
        public string ConfirmPassword { get; set; }
    }
}
