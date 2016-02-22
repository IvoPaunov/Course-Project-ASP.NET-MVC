namespace H8QMedia.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using H8QMedia.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Article;
    using H8QMedia.Web.ViewModels.SellingItem;
    using Kendo.Mvc.UI;

    [Authorize(Roles = ApplicationRoles.Admin)]
    public class ShopController : KendoAdminGridBaseController
    {
        private readonly ISellingItemsService items;

        public ShopController(ISellingItemsService items)
        {
            this.items = items;
        }

        // GET: Admin/Shop
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.items.GetAll()
                .To<SellingItemViewModel>();

            return this.GridOperationBigQueryable(data, request);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, SellingItemInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newArticle = this.Mapper.Map<SellingItem>(model);
                newArticle.SellerId = currentUserId;

                var modelId = this.items.Create(newArticle);

                model.Id = modelId;
                model.SellerId = currentUserId;
                model.SellerName = this.UserProfile.UserName;
                return this.GridOperationObject(model, request);
            }

            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, SellingItemInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var updated = this.Mapper.Map<SellingItem>(model);
                updated.Images = null;

                this.items.Update(model.Id, updated);

                return this.GridOperationObject(model, request);
            }

            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, SellingItemInputModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                this.items.Destroy(model.Id, null);
            }

            return this.GridOperationObject(model, request);
        }
    }
}
