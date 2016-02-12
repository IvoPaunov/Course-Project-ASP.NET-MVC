namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCommentContentLength)]
        [MaxLength(ValidationConstants.MaxCommentContentLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
