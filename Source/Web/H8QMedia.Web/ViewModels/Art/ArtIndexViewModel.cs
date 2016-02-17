namespace H8QMedia.Web.ViewModels.Art
{
    using System.Collections.Generic;
    using H8QMedia.Web.ViewModels.Article;

    public class ArtIndexViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ArticleViewModel> ArtArticles { get; set; }
    }
}
