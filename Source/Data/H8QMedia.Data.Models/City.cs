﻿namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class City : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCityNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCityNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}
