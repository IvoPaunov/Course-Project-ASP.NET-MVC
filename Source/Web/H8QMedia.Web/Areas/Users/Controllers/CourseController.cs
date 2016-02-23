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

    [Authorize(Roles = ApplicationRoles.Trainer)]
    public class CourseController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ICoursesService courses;
        private readonly IUsersService users;

        public CourseController(ICoursesService courses,  IUsersService users)
        {
            this.courses = courses;
            this.users = users;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newArticle = this.Mapper.Map<Course>(model);
                var imageUploader = new ImageUplouder();
                var images = new HashSet<Image>();
                string folderPath = Server.MapPath(WebConstants.ImagesMainPathMap + currentUserId);

                if (model.Files != null && model.Files.Count() > 0)
                {
                    foreach (var file in model.Files)
                    {
                        if (file != null
                            && (file.ContentType == WebConstants.ContentTypeJpg || file.ContentType == WebConstants.ContentTypePng)
                            && file.ContentLength < WebConstants.MaxImageFileSize)
                        {
                            images.Add(imageUploader.UploadImage(file, folderPath, currentUserId));
                        }
                    }
                }

                var trainer = this.users.UserById(currentUserId).FirstOrDefault();

                newArticle.Trainers.Add(trainer);

                var result = this.courses.Create(newArticle);

                return this.RedirectToAction("Course", "School", new { area = "", id = result });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var art = this.courses.GetById(id)
            .To<CourseInputModel>()
            .FirstOrDefault();

            return this.View(art);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var updatedArticle = this.Mapper.Map<Course>(model);
                var imageUploader = new ImageUplouder();
                var images = new HashSet<Image>();
                string folderPath = Server.MapPath(WebConstants.ImagesMainPathMap + currentUserId);

                if (model.Files != null && model.Files.Count() > 0)
                {
                    foreach (var file in model.Files)
                    {
                        if (file != null
                            && (file.ContentType == WebConstants.ContentTypeJpg || file.ContentType == WebConstants.ContentTypePng)
                            && file.ContentLength < WebConstants.MaxImageFileSize)
                        {
                            images.Add(imageUploader.UploadImage(file, folderPath, currentUserId));
                        }
                    }
                }

                images.ForEach(x => updatedArticle.Images.Add(x));

                this.courses.Update(model.Id, updatedArticle);

                return this.RedirectToAction("Course", "School", new { area = "", id = model.Id });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(int id)
        {
            this.courses.Destroy(id, this.UserProfile.Id);

            return this.RedirectToAction("Index", "School", new { area = "Users", id = 1 });
        }
    }
}