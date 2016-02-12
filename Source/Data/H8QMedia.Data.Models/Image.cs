namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image : FileInfo
    {
        public int EntityId { get; set; }

        public virtual InteractiveEntity Entity { get; set; }
    }
}
