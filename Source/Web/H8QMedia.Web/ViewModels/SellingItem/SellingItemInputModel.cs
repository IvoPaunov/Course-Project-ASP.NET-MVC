namespace H8QMedia.Web.ViewModels.SellingItem
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Image;

    public class SellingItemInputModel : IMapTo<SellingItem>, IMapFrom<SellingItem>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinInteractiveEntityTitleLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxInteractiveEntityTitleLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.MaxInteractiveEntityDescriptionLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        [AllowHtml]
        public string Description { get; set; }

        public string SellerId { get; set; }

        public string SellerName { get; set; }

        public decimal PriceBGN { get; set; }

        public int Availability { get; set; }

        [NotMapped]
        // [ValidateFile(ErrorMessage = "Please select a JPEG image smaller than 1MB")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<SellingItem, SellingItemInputModel>()
                    .ForMember(x => x.SellerName, opt => opt.MapFrom(x => x.Seller.UserName))
                    .ForMember(x => x.Images, opt => opt
                        .MapFrom(x => x.Images.Where(y => !y.IsDeleted).OrderByDescending(y => y.CreatedOn).ToList()));
        }
    }
}
