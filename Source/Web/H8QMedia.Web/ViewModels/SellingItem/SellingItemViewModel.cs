namespace H8QMedia.Web.ViewModels.SellingItem
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class SellingItemViewModel : IMapFrom<SellingItem>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [MinLength(
            ValidationConstants.MinInteractiveEntityTitleLength,
            ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(
            ValidationConstants.MaxInteractiveEntityTitleLength,
            ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Title { get; set; }

        [MaxLength(
            ValidationConstants.MaxInteractiveEntityDescriptionLength,
            ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Description { get; set; }

        public decimal PriceBGN { get; set; }

        public int Availability { get; set; }

        public string Seller { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<SellingItem, SellingItemViewModel>()
              .ForMember(x => x.Seller, opt => opt.MapFrom(x => x.Seller.UserName));
        }
    }
}
