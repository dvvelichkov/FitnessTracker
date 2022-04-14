using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Users
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(UserPasswordMaxLength, MinimumLength = UserPasswordMinLength,
            ErrorMessage = "The password must be between {2} and {1} characters long.")]
        public string Password { get; set; }
    }
}
