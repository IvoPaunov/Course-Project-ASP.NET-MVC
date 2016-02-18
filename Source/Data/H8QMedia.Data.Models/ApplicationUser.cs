namespace H8QMedia.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity, ITKeyEntity<string>
    {
        private ICollection<Article> atricles;
        private ICollection<Lesson> lessons;
        private ICollection<Course> coursesTraining;
        private ICollection<Course> coursesStuding;
        private ICollection<Comment> comments;
        private ICollection<Like> likes;
        private ICollection<SellingItem> sellingItems;
        private ICollection<Purchase> purchases;
        private ICollection<Address> addresses;

        public ApplicationUser()
        {
            this.atricles = new HashSet<Article>();
            this.comments = new HashSet<Comment>();
            this.coursesTraining = new HashSet<Course>();
            this.coursesStuding = new HashSet<Course>();
            this.likes = new HashSet<Like>();
            this.sellingItems = new HashSet<SellingItem>();
            this.purchases = new HashSet<Purchase>();
            this.addresses = new HashSet<Address>();
        }

        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string FirstName { get; set; }

        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string LastName { get; set; }

        public int? CityId { get; set; }

        public virtual City City { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? UserTypeCategoryId { get; set; }

        public virtual UserTypeCategory UserTypeCategory { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.atricles; }
            set { this.atricles = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Course> CoursesTraining
        {
            get { return this.coursesTraining; }
            set { this.coursesTraining = value; }
        }

        public virtual ICollection<Course> CoursesStuding
        {
            get { return this.coursesStuding; }
            set { this.coursesStuding = value; }
        }

        public virtual ICollection<SellingItem> SellingItems
        {
            get { return this.sellingItems; }
            set { this.sellingItems = value; }
        }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<Purchase> Purchases
        {
            get { return this.purchases; }
            set { this.purchases = value; }
        }

        public virtual ICollection<Address> Addresses
        {
            get { return this.addresses; }
            set { this.addresses = value; }
        }
    }
}
