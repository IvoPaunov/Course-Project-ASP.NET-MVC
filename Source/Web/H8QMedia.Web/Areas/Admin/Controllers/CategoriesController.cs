namespace H8QMedia.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using H8QMedia.Common;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Areas.Admin.ViewModels;
    using H8QMedia.Web.Areas.Admin.ViewModels.Category;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Article;
    using Kendo.Mvc.UI;

    [Authorize(Roles = ApplicationRoles.Admin)]
    public class CategoriesController : KendoAdminGridBaseController
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        // GET: Admin/Articles
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.categories.All()
                .To<CategoryViewModel>();

            return this.GridOperationBigQueryable(data, request);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var newCategory = this.Mapper.Map<Category>(model);

                var createdCategory = this.categories.Create(newCategory);

                model.Id = createdCategory.Id;

                return this.GridOperationObject(model, request);
            }

            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.categories.Update(model.Id, model.Name);

                return this.GridOperationObject(model, request);
            }

            return null;
        }
    }
}
