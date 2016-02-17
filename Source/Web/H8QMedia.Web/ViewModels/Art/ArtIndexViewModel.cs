namespace H8QMedia.Web.ViewModels.Art
{
    using System.Collections.Generic;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Common;

    public class ArtIndexViewModel
    {
        public PaginationViewModel PaginationModel { get; set; }

        public IEnumerable<ArticleViewModel> ArtArticles { get; set; }
    }
}
