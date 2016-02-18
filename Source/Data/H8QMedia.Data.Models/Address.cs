namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class Address : BaseModel<int>
    {
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinAddressLineLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxAddressLineLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string AddressLineOne { get; set; }

        [MinLength(ValidationConstants.MinAddressLineLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxAddressLineLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string AddressLineTwo { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTelephoneNumberLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxTelephoneNumberLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string TelephoneNumber { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinRecipientNamesLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxRecipientNamesLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string RecipientNames { get; set; }
    }
}
