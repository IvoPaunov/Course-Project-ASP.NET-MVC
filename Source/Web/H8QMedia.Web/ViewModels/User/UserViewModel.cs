namespace H8QMedia.Web.ViewModels.User
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserViewModel>()
              .ForMember(x => x.City, opt => opt.MapFrom(x => x.City.Name));

            configuration.CreateMap<ApplicationUser, UserViewModel>()
           .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country.Name));
        }
    }
}
