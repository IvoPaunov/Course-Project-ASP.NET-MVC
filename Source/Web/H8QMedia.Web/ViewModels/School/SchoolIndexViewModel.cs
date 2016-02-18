namespace H8QMedia.Web.ViewModels.School
{
    using System.Collections.Generic;

    using H8QMedia.Web.ViewModels.Common;
    using H8QMedia.Web.ViewModels.Course;

    public class SchoolIndexViewModel
    {
        public PaginationViewModel PaginationModel { get; set; }

        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
