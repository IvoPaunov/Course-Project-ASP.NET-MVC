namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class Country : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCountryNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCountryNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCountryCodeLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCountryCodeLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Code { get; set; }
    }
}
