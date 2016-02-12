namespace H8QMedia.Data.Models
{
    using H8QMedia.Data.Common.Models;

    public class Lesson : InteractiveEntity
    {
        public string YoutubeId { get; set; }

        public string TrainerId { get; set; }

        public virtual ApplicationUser Trainer { get; set; }
    }
}
