namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCategoryNameLength)]
        [MaxLength(ValidationConstants.MaxCategoryNameLength)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.MaxCategoryDescriptionLength)]
        public string Description { get; set; }
    }
}
