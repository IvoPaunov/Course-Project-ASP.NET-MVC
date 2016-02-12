namespace H8QMedia.Data.Models
{
    using System.Collections.Generic;

    using H8QMedia.Data.Common.Models;

    public class Article : InteractiveEntity
    {
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public ArticleType Type { get; set; }
    }
}
