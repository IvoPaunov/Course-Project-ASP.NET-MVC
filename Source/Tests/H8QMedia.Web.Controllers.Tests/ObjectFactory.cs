namespace H8QMedia.Web.Controllers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using Moq;

    public static class ObjectFactory
    {
        public static IQueryable<Category> cCategories = new List<Category>
        {
            new Category() { Id = 1, Name = "Nature" },
            new Category() { Id = 2, Name = "Graphics" }
        }.AsQueryable();

        public static IQueryable<Article> articles = new List<Article>
        {
            new Article()
            {
                Id = 1,
                Title = "The art article title 1",
                Description = "Description for art article 1",
                Author = new ApplicationUser()
                {
                    UserName = "pesho",
                    CreatedOn = new DateTime(2015, 4, 20)
                },
                Type = ArticleType.Art,
                CreatedOn = new DateTime(2015, 4, 20)
            },
            new Article()
            {
                Id = 2,
                Title = "The art article title 2",
                Description = "Description for art article 2",
                Author = new ApplicationUser()
                {
                    UserName = "pesho",
                    CreatedOn = new DateTime(2015, 4, 20)
                },
                Type = ArticleType.Art,
                CreatedOn = new DateTime(2015, 4, 22)
            },
            new Article()
            {
                Id = 3,
                Title = "The design article title 1",
                Description = "Description for design article 1",
                Author = new ApplicationUser()
                {
                    UserName = "pesho",
                    CreatedOn = new DateTime(2015, 4, 20)
                },
                Type = ArticleType.Design,
                CreatedOn = new DateTime(2015, 4, 22)
            },
            new Article()
            {
                Id = 4,
                Title = "The design article title 2",
                Description = "Description for design article 2",
                Author = new ApplicationUser()
                {
                    UserName = "pesho",
                    CreatedOn = new DateTime(2015, 4, 20)

                },
                Type = ArticleType.Design,
                CreatedOn = new DateTime(2015, 4, 22)
            }

        }.AsQueryable();

        public static IArticlesService GetArticleService()
        {
            var articlesService = new Mock<IArticlesService>();

            articlesService.Setup(x => x.Create(
                It.IsAny<Article>()))
                .Returns(2);

            articlesService.Setup(x => x.GetAll())
                .Returns(articles);

            articlesService.Setup(x => x.GetById(
                It.Is<int>(v => v == 1)))
                .Returns(articles.Where(x => x.Id == 1));

            return articlesService.Object;
        }
    }
}
