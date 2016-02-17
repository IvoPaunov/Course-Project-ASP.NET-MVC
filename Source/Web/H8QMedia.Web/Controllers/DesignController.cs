namespace H8QMedia.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Art;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Common;

    public class DesignController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly IArticlesService articles;

        public DesignController(IArticlesService articles)
        {
            this.articles = articles;
        }

        // GET: Public/Design
        public ActionResult Index(int page = 1)
        {
            var allItemsCount = this.articles.GetAll().Count(x => x.Type == ArticleType.Design);
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var arts = this.articles
                .GetAll()
                .Where(x => x.Type == ArticleType.Design)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .To<ArticleViewModel>()
                .ToList();

            var paginationModel = new PaginationViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Path = "/Design?page="
            };

            var model = new ArtIndexViewModel()
            {
                PaginationModel = paginationModel,
                ArtArticles = arts
            };

            return this.View(model);
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
