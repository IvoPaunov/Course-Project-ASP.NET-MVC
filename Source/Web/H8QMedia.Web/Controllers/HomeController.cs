namespace H8QMedia.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Course;
    using H8QMedia.Web.ViewModels.Home;
    using H8QMedia.Web.ViewModels.SellingItem;

// using Services.Data;

    public class HomeController : BaseController
    {
        private const int ItemsSection = 4;
        private readonly IArticlesService articles;
        private readonly ICoursesService courses;
        private readonly ISellingItemsService sellingItems;

        public HomeController(IArticlesService articles, ICoursesService courses, ISellingItemsService sellingItems)
        {
            this.articles = articles;
            this.courses = courses;
            this.sellingItems = sellingItems;
        }

        public ActionResult Index()
        {
            var arts =
                this.Cache.Get(
                    "last_arts",
                    () => this.articles
                             .GetAll()
                             .Where(x => x.Type == ArticleType.Art)
                             .OrderByDescending(x => x.CreatedOn)
                             .Take(ItemsSection)
                             .To<ArticleViewModel>()
                             .ToList(),
                    5 * 60);

            var designs =
                this.Cache.Get(
                    "last_designs",
                    () => this.articles
                             .GetAll()
                             .Where(x => x.Type == ArticleType.Design)
                             .OrderByDescending(x => x.CreatedOn)
                             .Take(ItemsSection)
                             .To<ArticleViewModel>()
                             .ToList(),
                    5 * 60);

            var courses =
               this.Cache.Get(
                   "last_courses",
                   () => this.courses
                            .GetAll()
                            .OrderByDescending(x => x.CreatedOn)
                            .Take(ItemsSection)
                            .To<CourseViewModel>()
                            .ToList(),
                   5 * 60);


            var itemsForSale =
               this.Cache.Get(
                   "last_items_for_sale",
                   () => this.sellingItems
                            .GetAll()
                            .OrderByDescending(x => x.CreatedOn)
                            .Take(ItemsSection)
                            .To<SellingItemViewModel>()
                            .ToList(),
                   5 * 60);

            var indexViewModel = new HomeIndexViewModel()
            {
                Arts = arts,
                Designs = designs,
                Courses = courses,
                ItemsForSale = itemsForSale
            };

            return this.View(indexViewModel);
        }
    }
}
