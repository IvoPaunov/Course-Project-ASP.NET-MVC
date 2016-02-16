namespace H8QMedia.Web.ViewModels.Article
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class InputArticleViewModel : IMapTo<Article>//, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ArticleType Type { get; set; }

        public string AuthorId { get; set; }

        [NotMapped]
        // [ValidateFile(ErrorMessage = "Please select a JPEG image smaller than 1MB")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            //configuration.CreateMap<InputArticleViewModel, Article>()
            //    .ForMember(x => x.Likes, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Count() : 0));
        }
    }
}