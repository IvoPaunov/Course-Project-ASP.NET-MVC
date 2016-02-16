namespace H8QMedia.Data.Seed
{
    using System;
    using System.Linq;
    using H8QMedia.Common;
    using H8QMedia.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AdminsSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
          //  var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Users.Any(u => u.UserName == "IvkoBivko"))
            {
                var user = new ApplicationUser
                {
                    Email = "ivo.paunov@gmail.com",
                    UserName = "IvkoBivko",
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, "123456");

                userManager.AddToRoles(
                    user.Id,
                    ApplicationRoles.Admin,
                    ApplicationRoles.Artist,
                    ApplicationRoles.Designer,
                    ApplicationRoles.Regular,
                    ApplicationRoles.Seller,
                    ApplicationRoles.Student,
                    ApplicationRoles.Trainer);
            }
        }
    }
}
