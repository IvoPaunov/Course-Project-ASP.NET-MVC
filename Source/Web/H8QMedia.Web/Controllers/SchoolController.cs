namespace H8QMedia.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Art;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Common;
    using H8QMedia.Web.ViewModels.Course;
    using H8QMedia.Web.ViewModels.School;

    public class SchoolController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ICoursesService courses;

        public SchoolController(ICoursesService courses)
        {
            this.courses = courses;
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
            return this.Json(id);
        }

        public ActionResult CourseObjectives(int page)
        {
            return this.Json(page);
        }

        public ActionResult Lesson(int id)
        {
            return this.Json(id);
        }

        public ActionResult Lessons(int page)
        {
            return this.Json(page);
        }
    }
}
