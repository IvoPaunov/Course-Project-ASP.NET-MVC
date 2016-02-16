namespace H8QMedia.Data.Models
{
    using System;
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
    }
}
