namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class Lesson : InteractiveEntity
    {
        [MaxLength(ValidationConstants.MaxLessonYoutubeVideoIdLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string YoutubeVideoId { get; set; }

        public bool IsPrivate { get; set; }

        public string TrainerId { get; set; }

        public virtual ApplicationUser Trainer { get; set; }

        public int CourseObjectiveId{ get; set; }

        public virtual CourseObjective CourseObjective { get; set; }
    }
}
