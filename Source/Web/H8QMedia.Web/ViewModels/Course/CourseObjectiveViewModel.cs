﻿namespace H8QMedia.Web.ViewModels.Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Ganss.XSS;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Lesson;

    public class CourseObjectiveViewModel : IMapFrom<CourseObjective>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription
        {
            get
            {
                var sanitizer = new HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");

                return sanitizer.Sanitize(this.Description);
            }
        }

        public string CreatorName { get; set; }

        public virtual ICollection<LessonViewModel> Lessons { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CourseObjective, CourseObjectiveViewModel>()
            .ForMember(x => x.CreatorName, opt => opt.MapFrom(x => x.Creator.UserName));
        }
    }
}
