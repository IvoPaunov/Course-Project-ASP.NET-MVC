namespace H8QMedia.Web.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Art;
    using H8QMedia.Web.ViewModels.Article;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class ArtController : KendoGridAdministrationController
    {
        private readonly IArticlesService articles;

        public ArtController(IArticlesService articles)
        {
            this.articles = articles;
        }

        // GET: Public/Art
        public ActionResult Index()
        {
            var arts = this.articles.GetAll()
                .To<ArticleViewModel>()
                .ToList();

            var model = new ArtIndexViewModel()
            {
                ArtArticles = arts
            };


            return this.View(model);
        }

        protected override IEnumerable GetData()
        {
            return this.articles
             .GetAll()
             .To<ArticleViewModel>();
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

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var arts = this.articles.GetAll()
                .To<ArticleViewModel>()
                .ToDataSourceResult(request);

            return this.Json(arts);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ArticleViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var modelId = this.articles.Create(
                    model.Title,
                    null,
                    this.UserProfile.Id);

                model.Id = modelId;
                return this.GridOperation(model, request);
            }

            return null;
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ArticleViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.articles.Update(
                  model.Id,
                    model.Title,
                    null);

                return this.GridOperation(model, request);
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ArticleViewModel model)
        {
            return this.GridOperation(model, request);
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
