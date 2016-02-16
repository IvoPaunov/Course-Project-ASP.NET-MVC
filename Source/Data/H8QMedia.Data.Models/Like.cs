 namespace H8QMedia.Data.Models
{
    using H8QMedia.Data.Common.Models;

    public class Like : BaseModel<int>
    {
        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public int EntityId { get; set; }

        public virtual InteractiveEntity Entity { get; set; }
    }
}
