namespace H8QMedia.Web.ViewModels.Like
{
    using System;
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class LikeViewModel : IMapFrom<Like>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string FromUserId { get; set; }

        public int EntityId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
