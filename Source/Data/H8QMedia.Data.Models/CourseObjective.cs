namespace H8QMedia.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public class CourseObjective : BaseModel<int>
    {
        private ICollection<Lesson> lessons;

        public CourseObjective()
        {
            this.lessons = new HashSet<Lesson>();
        }

        [Required]
        [MinLength(ValidationConstants.MinCourseObjectiveNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCourseObjectiveNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.MaxCourseObjectiveDescriptionLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Description { get; set; }

        public virtual ICollection<Lesson> Lessons
        {
            get { return this.lessons; }
            set { this.lessons = value; }
        }
    }
}
