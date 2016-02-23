namespace H8QMedia.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Course;
    using H8QMedia.Web.ViewModels.SellingItem;

    public class HomeIndexViewModel
    {
        public IEnumerable<CourseViewModel> Courses { get; set; }

        public IEnumerable<ArticleViewModel> Arts { get; set; }

        public IEnumerable<ArticleViewModel> Designs { get; set; }

        public IEnumerable<SellingItemViewModel> ItemsForSale { get; set; }
    }
}
