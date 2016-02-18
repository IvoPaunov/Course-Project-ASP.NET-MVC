namespace H8QMedia.Web.ViewModels.SellingItem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Ganss.XSS;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Comment;
    using H8QMedia.Web.ViewModels.Image;

    public class SellingItemViewModel : IMapFrom<SellingItem>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription
        {
            get
            {
                var sanitizer = new HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");

                return sanitizer.Sanitize(this.Description);
            }
        }

        public ICollection<CommentViewModel> Comments { get; set; }

        public int LikesCount { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public decimal PriceBGN { get; set; }

        public int Availability { get; set; }

        public string SellerName { get; set; }

        public string SellerId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<SellingItem, SellingItemViewModel>()
             .ForMember(x => x.LikesCount, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Count() : 0))
             .ForMember(x => x.SellerName, opt => opt.MapFrom(x => x.Seller.UserName))
             .ForMember(x => x.Comments, opt => opt
                 .MapFrom(x => x.Comments.Where(y => !y.IsDeleted).OrderByDescending(y => y.CreatedOn).ToList()))
             .ForMember(x => x.Images, opt => opt
                 .MapFrom(x => x.Images.Where(y => !y.IsDeleted).OrderByDescending(y => y.CreatedOn).ToList()));
        }
    }
}
