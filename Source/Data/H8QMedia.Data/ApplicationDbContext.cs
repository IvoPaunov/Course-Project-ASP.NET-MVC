namespace H8QMedia.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using H8QMedia.Data.Common.Models;
    using H8QMedia.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<CourseObjective> CourseObjectives { get; set; }

        public IDbSet<FileInfo> FileInfos { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Lesson> Lessons { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<SellingItem> SellingItems { get; set; }

        public IDbSet<UserTypeCategory> UserTypeCategories { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
