namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCategoryNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCategoryNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.MaxCategoryDescriptionLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Description { get; set; }
    }
}
