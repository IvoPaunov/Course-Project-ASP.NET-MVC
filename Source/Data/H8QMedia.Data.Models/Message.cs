namespace H8QMedia.Data.Models
{
    using H8QMedia.Data.Common.Models;

    public class Message : BaseModel<int>
    {
        public string Content { get; set; }

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }
}
