namespace H8QMedia.Data.Models
{
    using System.Collections.Generic;

    using H8QMedia.Data.Common.Models;

    public class CourseObjective : BaseModel<int>
    {
        private ICollection<Lesson> lessons;

        public CourseObjective()
        {
            this.lessons = new HashSet<Lesson>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Lesson> Lessons
        {
            get { return this.lessons; }
            set { this.lessons = value; }
        }
    }
}
