namespace H8QMedia.Web.ViewModels.Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Lesson;

    public class CourseObjectiveInputModel : IMapTo<CourseObjective>, IMapFrom<CourseObjective>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCourseObjectiveNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCourseObjectiveNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Title { get; set; }

        public string CreatorId { get; set; }

        [MaxLength(ValidationConstants.MaxCourseObjectiveDescriptionLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Description { get; set; }

        public virtual ICollection<LessonViewModel> Lessons { get; set; }
    }
}
