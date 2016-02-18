namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Glimpse.AspNet.Tab;
    using H8QMedia.Common.Extensions;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Constants;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.Infrastructure.UploadHelpers;
    using H8QMedia.Web.ViewModels.Course;
    using H8QMedia.Web.ViewModels.Lesson;

    public class LessonController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ILessonsService lessons;
        private readonly IUsersService users;

        public LessonController(ILessonsService lessons, IUsersService users)
        {
            this.lessons = lessons;
            this.users = users;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LessonInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newArticle = this.Mapper.Map<Lesson>(model);

                newArticle.TrainerId = currentUserId;

                var result = this.lessons.Create(newArticle);

                return this.RedirectToAction("Lesson", "School", new { area = "", id = result });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var art = this.lessons.GetById(id)
            .To<LessonInputModel>()
            .FirstOrDefault();

            return this.View(art);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LessonInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var updatedArticle = this.Mapper.Map<Lesson>(model);

                this.lessons.Update(model.Id, updatedArticle);

                return this.RedirectToAction("Lesson", "School", new { area = "", id = model.Id });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(int id)
        {
            this.lessons.Destroy(id, this.UserProfile.Id);

            return this.RedirectToAction("Index", "School", new { area = "Users", id = 1 });
        }
    }
}
