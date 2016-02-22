
namespace H8QMedia.Web.Areas.Admin.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCategoryNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCategoryNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}
