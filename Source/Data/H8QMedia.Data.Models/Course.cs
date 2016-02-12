namespace H8QMedia.Data.Models
{
    using System;
    using System.Collections.Generic;

    using H8QMedia.Data.Common.Models;

    public class Course : InteractiveEntity
    {
        private ICollection<ApplicationUser> students;
        private ICollection<ApplicationUser> trainers;
        private ICollection<CourseObjective> objectives;

        public Course()
        {
            this.students = new HashSet<ApplicationUser>();
            this.trainers = new HashSet<ApplicationUser>();
            this.objectives = new HashSet<CourseObjective>();
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<ApplicationUser> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<ApplicationUser> Trainers
        {
            get { return this.trainers; }
            set { this.trainers = value; }
        }

        public virtual ICollection<CourseObjective> Objectives
        {
            get { return this.objectives; }
            set { this.objectives = value; }
        }
    }
}
