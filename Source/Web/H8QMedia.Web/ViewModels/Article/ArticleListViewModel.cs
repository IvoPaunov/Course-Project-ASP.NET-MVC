namespace H8QMedia.Web.ViewModels.Article
{
    using System.Collections.Generic;

    public class ArticleListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ArticleListViewModel> Artikles { get; set; }
    }
}
