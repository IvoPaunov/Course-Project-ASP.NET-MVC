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

        [Required]
        [MinLength(ValidationConstants.MinAddressLineLength)]
        [MaxLength(ValidationConstants.MaxAddressLineLength)]
        public string AddressLineOne { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinAddressLineLength)]
        [MaxLength(ValidationConstants.MaxAddressLineLength)]
        public string AddressLineTwo { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTelephoneNumberLength)]
        [MaxLength(ValidationConstants.MaxTelephoneNumberLength)]
        public string TelephoneNumber { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinRecipientNamesLength)]
        [MaxLength(ValidationConstants.MaxRecipientNamesLength)]
        public string RecipientNames { get; set; }
    }
}
