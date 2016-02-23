namespace H8QMedia.Web.Controllers
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Art;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Common;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class ArtController : KendoGridAdministrationController
    {
        private const int ItemsPerPage = 6;
        private readonly IArticlesService articles;

        public ArtController(IArticlesService articles)
        {
            this.articles = articles;
        }

        // GET: Public/Art
        public ActionResult Index(int page = 1)
        {
           // var page = page;
            var allItemsCount = this.articles.GetAll().Count(x => x.Type == ArticleType.Art);
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var arts = this.articles
                .GetAll()
                .Where(x => x.Type == ArticleType.Art)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .To<ArticleViewModel>()
                .ToList();

            var paginationModel = new PaginationViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Path = "/Art?page="
            };

            var model = new ArtIndexViewModel()
            {
                PaginationModel = paginationModel,
                ArtArticles = arts
            };

            return this.View(model);
        }

        protected override IEnumerable GetData()
        {
            var arts = this.articles
             .GetAll()
             .To<ArticleViewModel>();

            return arts;
        }

        protected override T GetById<T>(object id)
        {
            return this.articles
                .GetById(int.Parse(id.ToString())) as T;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var art = this.articles.GetById(id)
                .To<ArticleViewModel>()
                .FirstOrDefault();

            return this.View(art);
        }
    }
}
