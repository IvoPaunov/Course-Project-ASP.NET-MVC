namespace H8QMedia.Web.Areas.Users.ViewModels.Message
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class MessageInputModelCreate : IMapFrom<Message>, IMapTo<Message>
    {
        public MessageInputModelCreate()
        {
        }

        public MessageInputModelCreate(string senderId, string recipientId, string recipientName)
        {
            this.RecipientId = senderId;
            this.RecipientId = recipientId;
            this.RecipientName = recipientName;
        }

        [Required]
        [UIHint("MultiLineText")]
        [MaxLength(ValidationConstants.MaxMessageContentLength)]
        public string Content { get; set; }

        public string SenderId { get; set; }

        public string RecipientId { get; set; }

        [NotMapped]
        public string RecipientName { get; set; }
    }
}
