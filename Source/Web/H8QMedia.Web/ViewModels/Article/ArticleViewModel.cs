namespace H8QMedia.Web.ViewModels.Article
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Image;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
      //  [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ArticleType { get; set; }

       // [HiddenInput(DisplayValue = false)]
        public string AuthorName { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public int LikesCount { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleViewModel>()
                .ForMember(x => x.LikesCount, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Count() : 0))
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(x => x.ArticleType, opt => opt.MapFrom(x => x.Type.ToString()));
        }
    }
}
