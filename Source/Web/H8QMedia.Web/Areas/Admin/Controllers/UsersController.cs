namespace H8QMedia.Web.Areas.Admin.Controllers
{
    using System;
    using System.Web.Mvc;

    using H8QMedia.Common;
    using H8QMedia.Data;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Areas.Admin.ViewModels.User;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Article;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    [Authorize(Roles = ApplicationRoles.Admin)]
    public class UsersController : KendoAdminGridBaseController
    {
        private readonly IUsersService users;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(IUsersService users)
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(userscontext);
            this.userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(userscontext);
            this.roleManager = new RoleManager<IdentityRole>(roleStore);

            this.users = users;
        }

        // GET: Admin/Articles
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.users.GetAll()
                .To<UserAdministrationModel>();

            return this.GridOperationBigQueryable(data, request);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, UserAdministrationModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CreatedOn = DateTime.Now
                };

                var password = string.IsNullOrEmpty(model.NewPassword) ? "123456" : model.NewPassword;

                this.userManager.Create(newUser, password);

                if (model.IsAdmin)
                {
                    this.userManager.AddToRole(newUser.Id, ApplicationRoles.Admin);
                }

                if (model.IsArtist)
                {
                    this.userManager.AddToRole(newUser.Id, ApplicationRoles.Artist);
                }

                if (model.IsDesigner)
                {
                    this.userManager.AddToRole(newUser.Id, ApplicationRoles.Designer);
                }

                if (model.IsRegular)
                {
                    this.userManager.AddToRole(newUser.Id, ApplicationRoles.Regular);
                }

                if (model.IsSeller)
                {
                    this.userManager.AddToRole(newUser.Id, ApplicationRoles.Seller);
                }

                if (model.IsStudent)
                {
                    this.userManager.AddToRole(newUser.Id, ApplicationRoles.Student);
                }

                if (model.IsTrainer)
                {
                    this.userManager.AddToRole(newUser.Id, ApplicationRoles.Trainer);
                }

                model.Id = newUser.Id;
                model.NewPassword = string.Empty;

                return this.GridOperationObject(model, request);
            }

            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, UserAdministrationModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var selectedUser = this.userManager.FindById(model.Id);
                selectedUser.UserName = model.UserName;
                selectedUser.Email = model.Email;
                selectedUser.FirstName = model.FirstName;
                selectedUser.LastName = model.LastName;

                this.userManager.Update(selectedUser);

                // Admin
                if (model.IsAdmin && !this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Admin))
                {
                    this.userManager.AddToRole(selectedUser.Id, ApplicationRoles.Admin);
                }
                else if (!model.IsAdmin && this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Admin))
                {
                    this.userManager.RemoveFromRole(selectedUser.Id, ApplicationRoles.Admin);
                }

                // Artist
                if (model.IsArtist && !this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Artist))
                {
                    this.userManager.AddToRole(selectedUser.Id, ApplicationRoles.Artist);
                }
                else if (!model.IsArtist && this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Artist))
                {
                    this.userManager.RemoveFromRole(selectedUser.Id, ApplicationRoles.Artist);
                }

                // Designer
                if (model.IsDesigner && !this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Designer))
                {
                    this.userManager.AddToRole(selectedUser.Id, ApplicationRoles.Designer);
                }
                else if (!model.IsDesigner && this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Designer))
                {
                    this.userManager.RemoveFromRole(selectedUser.Id, ApplicationRoles.Designer);
                }

                // Regular
                if (model.IsRegular && !this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Regular))
                {
                    this.userManager.AddToRole(selectedUser.Id, ApplicationRoles.Regular);
                }
                else if (!model.IsRegular && this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Regular))
                {
                    this.userManager.RemoveFromRole(selectedUser.Id, ApplicationRoles.Regular);
                }

                // Seller
                if (model.IsSeller && !this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Seller))
                {
                    this.userManager.AddToRole(selectedUser.Id, ApplicationRoles.Seller);
                }
                else if (!model.IsSeller && this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Seller))
                {
                    this.userManager.RemoveFromRole(selectedUser.Id, ApplicationRoles.Seller);
                }

                // Student
                if (model.IsStudent && !this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Student))
                {
                    this.userManager.AddToRole(selectedUser.Id, ApplicationRoles.Student);
                }
                else if (!model.IsStudent && this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Student))
                {
                    this.userManager.RemoveFromRole(selectedUser.Id, ApplicationRoles.Student);
                }

                // Trainer
                if (model.IsTrainer && !this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Trainer))
                {
                    this.userManager.AddToRole(selectedUser.Id, ApplicationRoles.Trainer);
                }
                else if (!model.IsTrainer && this.userManager.IsInRole(selectedUser.Id, ApplicationRoles.Trainer))
                {
                    this.userManager.RemoveFromRole(selectedUser.Id, ApplicationRoles.Trainer);
                }

                return this.GridOperationObject(model, request);
            }

            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, UserAdministrationModel model)
        {
            if (ModelState.IsValid && model != null)
            {
               this.users.Destroy(model.Id);
            }

            return this.GridOperationObject(model, request);
        }
    }
}
