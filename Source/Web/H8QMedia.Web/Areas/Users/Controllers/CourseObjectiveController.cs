namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using H8QMedia.Common;
    using H8QMedia.Common.Extensions;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Constants;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.Infrastructure.UploadHelpers;
    using H8QMedia.Web.ViewModels.Course;

    public class CourseObjectiveController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ICourseObjectivesService objectives;
        private readonly IUsersService users;

        public CourseObjectiveController(ICourseObjectivesService objectives, IUsersService users)
        {
            this.objectives = objectives;
            this.users = users;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseObjectiveInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newArticle = this.Mapper.Map<CourseObjective>(model);

                newArticle.CreatorId = currentUserId;

                var result = this.objectives.Create(newArticle);

                return this.RedirectToAction("CourseObjective", "School", new { area = "", id = result });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var art = this.objectives.GetById(id)
            .To<CourseObjectiveInputModel>()
            .FirstOrDefault();

            return this.View(art);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseObjectiveInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var updatedArticle = this.Mapper.Map<CourseObjective>(model);

                this.objectives.Update(model.Id, updatedArticle);

                return this.RedirectToAction("CourseObjective", "School", new { area = "", id = model.Id });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(int id)
        {
            this.objectives.Destroy(id, this.UserProfile.Id);

            return this.RedirectToAction("Index", "School", new { area = "Users", id = 1 });
        }
    }
}