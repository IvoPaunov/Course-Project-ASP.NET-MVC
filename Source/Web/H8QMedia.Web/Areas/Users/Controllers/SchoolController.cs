namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Areas.Users.ViewModels.Message;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Course;
    using H8QMedia.Web.ViewModels.User;

    public class SchoolController : BaseController
    {
        private ICoursesService courses;
        private IUsersService users;

        public SchoolController(ICoursesService courses, IUsersService users)
        {
            this.courses = courses;
            this.users = users;
        }

        public ActionResult Index(string id)
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetUserProfilePartial()
        {
            var userName = this.UserProfile.UserName;

            var userData =
                this.Cache.Get(
                    userName,
                    () => this.users
                        .UserById(this.UserProfile.Id)
                        .To<UserViewModel>()
                        .FirstOrDefault(),
                    1 * 60);

            return this.PartialView("_UserProfilePartial", userData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetCoursesPartial()
        {
            var model = this.courses
                .GetByTrainerId(this.UserProfile.Id)
                .To<CourseViewModel>();

            return this.PartialView("_CoursesPartial", model);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOutboxMessagesPartial()
        {
            var model = this.courses
                  .GetByTrainerId(this.UserProfile.Id)
                  .To<CourseViewModel>();

            return this.PartialView("_CoursesPartial", model);
        }

        [Authorize]
        public ActionResult Update(int id)
        {
            var model = this.courses
           .GetByTrainerId(this.UserProfile.Id)
           .To<CourseViewModel>();

            return this.PartialView("_CoursesPartial", model);
        }
    }
}
