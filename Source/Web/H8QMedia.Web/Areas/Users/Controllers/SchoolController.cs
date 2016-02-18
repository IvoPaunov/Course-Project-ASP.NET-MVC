namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Areas.Users.ViewModels.Message;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Course;
    using H8QMedia.Web.ViewModels.Lesson;
    using H8QMedia.Web.ViewModels.User;

    public class SchoolController : BaseController
    {
        private ICoursesService courses;
        private ICourseObjectivesService objectives;
        private ILessonsService lessons;
        private IUsersService users;

        public SchoolController(ICoursesService courses, IUsersService users, ICourseObjectivesService objectives, ILessonsService lessons)
        {
            this.courses = courses;
            this.users = users;
            this.lessons = lessons;
            this.objectives = objectives;
        }

        public ActionResult Index(string id)
        {
            return View();
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
        public ActionResult GetCoursesObjectivesPartial()
        {
            var model = this.objectives
                  .GetByCreatorId(this.UserProfile.Id)
                  .To<CourseObjectiveViewModel>();

            return this.PartialView("_CoursesObjectivesPartial", model);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetLessonsPartial()
        {
            var model = this.lessons
                .GetByTrainerId(this.UserProfile.Id)
                .To<LessonViewModel>();

            return this.PartialView("_LessonsPartial", model);
        }
    }
}
