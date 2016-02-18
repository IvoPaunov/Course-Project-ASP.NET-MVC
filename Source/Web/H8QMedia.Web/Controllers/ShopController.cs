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
    using H8QMedia.Web.ViewModels.SellingItem;
    using H8QMedia.Web.ViewModels.Shop;

    public class ShopController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ISellingItemsService sellingItems;

        public ShopController(ISellingItemsService sellingItems)
        {
            this.sellingItems = sellingItems;
        }

        // GET: Public/Shop
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var allItemsCount = this.sellingItems
                .GetAll()
                .Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var items = this.sellingItems
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .To<SellingItemViewModel>()
                .ToList();

            var paginationModel = new PaginationViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Path = "/Shop?page=" 
            };

            var model = new ShopIndexViewModel()
            {
                PaginationModel = paginationModel,
                ItemsForSale = items
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var art = this.sellingItems.GetById(id)
                .To<SellingItemViewModel>()
                .FirstOrDefault();

            return this.View(art);
        }
    }
}
