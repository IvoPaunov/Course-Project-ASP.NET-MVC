namespace H8QMedia.Web.ViewModels.Image
{
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>, IMapTo<Image>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string OriginalFileName { get; set; }

        public string UrlPath { get; set; }
    }
}
