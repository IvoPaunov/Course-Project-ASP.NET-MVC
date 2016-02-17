namespace H8QMedia.Web.ViewModels.User
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Arts added")]
        public int ArtsAdded { get; set; }

        [DisplayName("Designs added")]
        public int DesignsAdded { get; set; }

        [DisplayName("SellingItems added")]
        public int SellingItemsAdded { get; set; }

        [DisplayName("Courses as trainer")]
        public int CoursesAsTrainer { get; set; }

        [DisplayName("Courses as student")]
        public int CoursesAsStudent { get; set; }

        [DisplayName("Purchases made")]
        public int PurchasesMade { get; set; }

        [DisplayName("Comments Made")]
        public int CommentsMade { get; set; }

        [DisplayName("Likes given")]
        public int LikesGiven { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(x => x.City, opt => opt.MapFrom(x => x.City.Name))
                .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country.Name))
                .ForMember(x => x.ArtsAdded, opt => opt.MapFrom(x => x.Articles.Any() ? x.Articles.Count(y => y.Type == ArticleType.Art && !y.IsDeleted) : 0))
                .ForMember(x => x.DesignsAdded, opt => opt.MapFrom(x => x.Articles.Any() ? x.Articles.Count(y => y.Type == ArticleType.Design && !y.IsDeleted) : 0))
                .ForMember(x => x.SellingItemsAdded, opt => opt.MapFrom(x => x.SellingItems.Any() ? x.SellingItems.Count(y => !y.IsDeleted) : 0))
                .ForMember(x => x.CoursesAsTrainer, opt => opt.MapFrom(x => x.CoursesTraining.Any() ? x.CoursesTraining.Count(y => !y.IsDeleted) : 0))
                .ForMember(x => x.CoursesAsStudent, opt => opt.MapFrom(x => x.CoursesStuding.Any() ? x.CoursesStuding.Count(y => !y.IsDeleted) : 0))
                .ForMember(x => x.PurchasesMade, opt => opt.MapFrom(x => x.Purchases.Any() ? x.Purchases.Count(y => !y.IsDeleted) : 0))
                .ForMember(x => x.CommentsMade, opt => opt.MapFrom(x => x.Comments.Any() ? x.Comments.Count(y => !y.IsDeleted) : 0))
                .ForMember(x => x.LikesGiven, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Count(y => !y.IsDeleted) : 0))
              ;
        }
    }
}
