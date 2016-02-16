namespace H8QMedia.Web.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public abstract class KendoGridAdministrationController : BaseController
    {
        protected abstract IEnumerable GetData();

        protected abstract T GetById<T>(object id) where T : class;

        //[HttpPost]
        //public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        //{
        //    var ads =
        //        this.GetData()
        //        .ToDataSourceResult(request);

        //    return this.Json(ads);
        //}

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : class
            where TViewModel : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById<TModel>(id);
                this.Mapper.Map<TViewModel, TModel>(model, dbModel);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private void ChangeEntityStateAndSave(object dbModel, EntityState state)
        {
            //var entry = this.Data.Context.Entry(dbModel);
            //entry.State = state;
            //this.Data.SaveChanges();
        }
    }
}