namespace H8QMedia.Web.Areas.Users.ViewModels.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class InputCommentViewModelCreate : IMapTo<Comment>
    {
        public InputCommentViewModelCreate()
        {
        }

        public InputCommentViewModelCreate(int articleId)
        {
            this.EntityId = articleId;
        }

        [Required]
        [UIHint("MultiLineText")]
        [MaxLength(ValidationConstants.MaxCommentContentLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int EntityId { get; set; }
    }
}
