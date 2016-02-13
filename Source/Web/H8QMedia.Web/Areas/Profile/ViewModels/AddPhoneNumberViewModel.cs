namespace H8QMedia.Web.Areas.Profile.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}
