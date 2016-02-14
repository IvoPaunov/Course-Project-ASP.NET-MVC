namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class UserTypeCategory : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinUserTypeCategoryNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxUserTypeCategoryNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}
