namespace H8QMedia.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Common;
    using H8QMedia.Web.ViewModels.Course;
    using H8QMedia.Web.ViewModels.Lesson;
    using H8QMedia.Web.ViewModels.School;

    public class SchoolController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ICoursesService courses;
        private readonly ICourseObjectivesService objectives;
        private readonly ILessonsService lessons;

        public SchoolController(ICoursesService courses, ICourseObjectivesService objectives, ILessonsService lessons)
        {
            this.courses = courses;
            this.objectives = objectives;
            this.lessons = lessons;
        }

        public ActionResult Index(int page = 1)
        {
            // var page = page;
            var allItemsCount = this.courses.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var courses = this.courses
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .To<CourseViewModel>()
                .ToList();

            var paginationModel = new PaginationViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Path = "/School/Index/"
            };

            var model = new SchoolIndexViewModel()
            {
                PaginationModel = paginationModel,
                Courses = courses
            };

            return this.View(model);
        }

        public ActionResult Course(int id)
        {
            var course = this.courses
              .GetById(id)
              .To<CourseViewModel>()
              .FirstOrDefault();

            return this.View("CourseDetails", course);
        }

        public ActionResult Courses(int page)
        {
            var course = this.courses
                .GetById(page)
                .To<CourseViewModel>()
                .FirstOrDefault();

            return this.View("CourseDetails", course);
        }

        public ActionResult CourseObjective(int id)
        {
            var objective = this.objectives
               .GetById(id)
               .To<CourseObjectiveViewModel>()
               .FirstOrDefault();

            return this.View("CourseObjectiveDetails", objective);
        }

        public ActionResult CourseObjectives(int page)
        {
            return this.Json(page);
        }

        public ActionResult Lesson(int id)
        {
            var lesson = this.lessons
               .GetById(id)
               .To<LessonViewModel>()
               .FirstOrDefault();

            return this.View("LessonDetails", lesson);
        }

        public ActionResult Lessons(int page)
        {
            return this.Json(page);
        }
    }
}
