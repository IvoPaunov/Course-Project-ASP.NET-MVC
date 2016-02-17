namespace H8QMedia.Web.ViewModels.Article
{
    using System;
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
    using H8QMedia.Web.ViewModels.Image;

    public class ArticleInputModel : IMapTo<Article>, IMapFrom<Article>, IHaveCustomMappings
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

        public ArticleType Type { get; set; }

        public string AuthorId { get; set; }

        [NotMapped]
        // [ValidateFile(ErrorMessage = "Please select a JPEG image smaller than 1MB")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleInputModel>()
                 .ForMember(x => x.Images, opt => opt
                     .MapFrom(x => x.Images.Where(y => !y.IsDeleted).OrderByDescending(y => y.CreatedOn).ToList()));
        }
    }
}