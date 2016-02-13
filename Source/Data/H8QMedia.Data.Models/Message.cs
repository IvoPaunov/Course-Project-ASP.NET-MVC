namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class Message : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinMessageContentLength)]
        [MaxLength(ValidationConstants.MaxMessageContentLength)]
        public string Content { get; set; }

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }
}
