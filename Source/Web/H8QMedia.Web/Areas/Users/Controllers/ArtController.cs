namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
    using H8QMedia.Web.ViewModels.Art;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Common;

    [Authorize(Roles = ApplicationRoles.Artist)]
    public class ArtController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly IArticlesService articles;

        public ArtController(IArticlesService articles)
        {
            this.articles = articles;
        }

        // GET: Public/Art
        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var page = id;
            var allItemsCount = this.articles
                .GetAll()
                .Count(x => x.Type == ArticleType.Art && x.AuthorId == this.UserProfile.Id);
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var arts = this.articles
                .GetByUserId(this.UserProfile.Id)
                .Where(x => x.Type == ArticleType.Art)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .To<ArticleViewModel>()
                .ToList();

            var paginationModel = new PaginationViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Path = "/Users/Art/Index/"
            };

            var model = new ArtIndexViewModel()
            {
                PaginationModel = paginationModel,
                ArtArticles = arts
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newArticle = this.Mapper.Map<Article>(model);
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

                newArticle.Type = ArticleType.Art;
                newArticle.AuthorId = currentUserId;
                newArticle.Images = images;

                var result = this.articles.Create(newArticle);

                return this.RedirectToAction("Details", "Art", new { area = "", id = result });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var art = this.articles.GetById(id)
            .To<ArticleInputModel>()
            .FirstOrDefault();

            return this.View(art);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var updatedArticle = this.Mapper.Map<Article>(model);
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

                this.articles.Update(model.Id, updatedArticle);

                return this.RedirectToAction("Details", "Art", new { area = "", id = model.Id });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(int id)
        {
            this.articles.Destroy(id, this.UserProfile.Id);

            return this.RedirectToAction("Index", "Art", new { area = "Users", id = 1 });
        }
    }
}
