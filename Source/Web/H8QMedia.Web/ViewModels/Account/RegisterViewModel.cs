namespace H8QMedia.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using H8QMedia.Data.Common;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinUserNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxUserUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
