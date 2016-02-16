namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using H8QMedia.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Constants;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.Infrastructure.UploadHelpers;
    using H8QMedia.Web.ViewModels.Art;
    using H8QMedia.Web.ViewModels.Article;

    [Authorize(Roles = ApplicationRoles.Artist)]
    public class ArtController : BaseController
    {
        private readonly IArticlesService articles;

        public ArtController(IArticlesService articles)
        {
            this.articles = articles;
        }

        // GET: Public/Art
        public ActionResult Index()
        {
            var arts = this.articles.GetAll()
                .To<ArticleViewModel>()
                .ToList();

            var model = new ArtIndexViewModel()
            {
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
        public ActionResult Create(InputArticleViewModel model)
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
                        else
                        {
                            return this.View(model);
                        }
                    }
                }

                newArticle.AuthorId = currentUserId;
                newArticle.Images = images;

                var result = this.articles.Create(newArticle);

                return this.RedirectToAction("Details", "Art", new { area = "", id = result });
            }

            return this.View(model);
        }
    }
}
