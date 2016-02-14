namespace H8QMedia.Data.Seed
{
    using System.Linq;
    using H8QMedia.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RolesSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = ApplicationRoles.Admin });
                roleManager.Create(new IdentityRole { Name = ApplicationRoles.Artist });
                roleManager.Create(new IdentityRole { Name = ApplicationRoles.Designer });
                roleManager.Create(new IdentityRole { Name = ApplicationRoles.Regular });
                roleManager.Create(new IdentityRole { Name = ApplicationRoles.Seller });
                roleManager.Create(new IdentityRole { Name = ApplicationRoles.Student });
                roleManager.Create(new IdentityRole { Name = ApplicationRoles.Trainer });
            }
        }
    }
}
