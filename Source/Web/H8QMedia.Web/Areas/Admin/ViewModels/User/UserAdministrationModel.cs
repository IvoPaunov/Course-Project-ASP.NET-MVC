namespace H8QMedia.Web.Areas.Admin.ViewModels.User
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using H8QMedia.Common;
    using H8QMedia.Data;
    using H8QMedia.Data.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserAdministrationModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>, IHaveCustomMappings
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinUserNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxUserUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsStudent { get; set; }

        public bool IsArtist { get; set; }

        public bool IsDesigner { get; set; }

        public bool IsSeller { get; set; }

        public bool IsRegular { get; set; }

        public bool IsTrainer { get; set; }

        public string NewPassword { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();

            var roles = userscontext.Roles.OrderBy(x => x.Name).ToList();

            var adminRoleId = roles.FirstOrDefault(x => x.Name == ApplicationRoles.Admin).Id;
            var artistRoleId = roles.FirstOrDefault(x => x.Name == ApplicationRoles.Artist).Id;
            var designerRoleId = roles.FirstOrDefault(x => x.Name == ApplicationRoles.Designer).Id;
            var regularRoleId = roles.FirstOrDefault(x => x.Name == ApplicationRoles.Regular).Id;
            var sellerRoleId = roles.FirstOrDefault(x => x.Name == ApplicationRoles.Seller).Id;
            var studentRoleId = roles.FirstOrDefault(x => x.Name == ApplicationRoles.Student).Id;
            var trainerRoleId = roles.FirstOrDefault(x => x.Name == ApplicationRoles.Trainer).Id;

            configuration.CreateMap<ApplicationUser, UserAdministrationModel>()
                .ForMember(x => x.IsAdmin, opt => opt.MapFrom(x => x.Roles.Any( r => r.RoleId == adminRoleId)))
                .ForMember(x => x.IsArtist, opt => opt.MapFrom(x => x.Roles.Any(r => r.RoleId == artistRoleId)))
                .ForMember(x => x.IsDesigner, opt => opt.MapFrom(x => x.Roles.Any(r => r.RoleId == designerRoleId)))
                .ForMember(x => x.IsRegular, opt => opt.MapFrom(x => x.Roles.Any(r => r.RoleId == regularRoleId)))
                .ForMember(x => x.IsSeller, opt => opt.MapFrom(x => x.Roles.Any(r => r.RoleId == sellerRoleId)))
                .ForMember(x => x.IsStudent, opt => opt.MapFrom(x => x.Roles.Any(r => r.RoleId == studentRoleId)))
                .ForMember(x => x.IsTrainer, opt => opt.MapFrom(x => x.Roles.Any(r => r.RoleId == trainerRoleId)));
        }
    }
}
