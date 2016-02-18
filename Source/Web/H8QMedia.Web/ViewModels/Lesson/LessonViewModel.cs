namespace H8QMedia.Web.ViewModels.Lesson
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Ganss.XSS;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class LessonViewModel : IMapFrom<Lesson>, IHaveCustomMappings
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

        [MaxLength(ValidationConstants.MaxLessonYoutubeVideoIdLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string YoutubeVideoId { get; set; }

        public bool IsPrivate { get; set; }

        public string TrainerId { get; set; }

        public string TrainerName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Lesson, LessonViewModel>()
               .ForMember(x => x.TrainerName, opt => opt.MapFrom(x => x.Trainer.UserName));
        }
    }
}
