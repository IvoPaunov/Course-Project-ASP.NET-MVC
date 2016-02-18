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
    using H8QMedia.Web.ViewModels.Art;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.Common;
    using H8QMedia.Web.ViewModels.SellingItem;
    using H8QMedia.Web.ViewModels.Shop;

    [Authorize(Roles = ApplicationRoles.Seller)]
    public class SellingItemsController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ISellingItemsService sellingItems;

        public SellingItemsController(ISellingItemsService sellingItems)
        {
            this.sellingItems = sellingItems;
        }

        // GET: Public/Art
        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var page = id;
            var allItemsCount = this.sellingItems
                .GetAll()
                .Count(x =>  x.SellerId == this.UserProfile.Id);
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var items = this.sellingItems
                .GetByUserId(this.UserProfile.Id)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .To<SellingItemViewModel>()
                .ToList();

            var paginationModel = new PaginationViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Path = "/Users/SellingItems/Index/"
            };

            var model = new ShopIndexViewModel()
            {
                PaginationModel = paginationModel,
                ItemsForSale = items
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
        public ActionResult Create(SellingItemInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newArticle = this.Mapper.Map<SellingItem>(model);
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
                
                newArticle.SellerId = currentUserId;
                newArticle.Images = images;

                var result = this.sellingItems.Create(newArticle);

                return this.RedirectToAction("Details", "Shop", new { area = "", id = result });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var art = this.sellingItems.GetById(id)
            .To<SellingItemInputModel>()
            .FirstOrDefault();

            return this.View(art);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SellingItemInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var updatedArticle = this.Mapper.Map<SellingItem>(model);
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

                this.sellingItems.Update(model.Id, updatedArticle);

                return this.RedirectToAction("Details", "Shop", new { area = "", id = model.Id });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(int id)
        {
            this.sellingItems.Destroy(id, this.UserProfile.Id);

            return this.RedirectToAction("Index", "SellingItems", new { area = "Users", id = 1 });
        }
    }
}