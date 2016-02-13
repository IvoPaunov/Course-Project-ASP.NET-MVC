namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class Country : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCountryNameLength)]
        [MaxLength(ValidationConstants.MaxCountryNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCountryCodeLength)]
        [MaxLength(ValidationConstants.MaxCountryCodeLength)]
        public string Code { get; set; }
    }
}
