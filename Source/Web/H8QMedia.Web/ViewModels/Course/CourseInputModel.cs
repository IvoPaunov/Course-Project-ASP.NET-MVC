namespace H8QMedia.Web.ViewModels.Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Comment;
    using H8QMedia.Web.ViewModels.Image;
    using H8QMedia.Web.ViewModels.User;

    public class CourseInputModel : IMapTo<Course>, IMapFrom<Course>, IHaveCustomMappings
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

        [MaxLength(
            ValidationConstants.MaxInteractiveEntityDescriptionLength,
            ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Description { get; set; }

        public virtual ICollection<ImageViewModel> Images { get; set; }

        [NotMapped]
        // [ValidateFile(ErrorMessage = "Please select a JPEG image smaller than 1MB")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Course, CourseInputModel>()
                 .ForMember(x => x.Images, opt => opt
                     .MapFrom(x => x.Images.Where(y => !y.IsDeleted).OrderByDescending(y => y.CreatedOn).ToList()));
        }
    }
}
