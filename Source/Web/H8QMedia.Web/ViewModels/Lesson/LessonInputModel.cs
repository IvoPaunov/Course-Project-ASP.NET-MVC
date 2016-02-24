namespace H8QMedia.Web.ViewModels.Lesson
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class LessonInputModel : IMapTo<Lesson>, IMapFrom<Lesson>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [MinLength(
            ValidationConstants.MinInteractiveEntityTitleLength,
            ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(
            ValidationConstants.MaxInteractiveEntityTitleLength,
            ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Title { get; set; }

        [AllowHtml]
        [MaxLength(
            ValidationConstants.MaxInteractiveEntityDescriptionLength,
            ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Description { get; set; }

        [MaxLength(ValidationConstants.MaxLessonYoutubeVideoIdLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string YoutubeVideoId { get; set; }

        public bool IsPrivate { get; set; }

        public string TrainerId { get; set; }
    }
}
