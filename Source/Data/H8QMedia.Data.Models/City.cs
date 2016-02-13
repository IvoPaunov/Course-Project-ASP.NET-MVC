namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class City : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCityNameLength)]
        [MaxLength(ValidationConstants.MaxCityNameLength)]
        public string Name { get; set; }

    }
}
