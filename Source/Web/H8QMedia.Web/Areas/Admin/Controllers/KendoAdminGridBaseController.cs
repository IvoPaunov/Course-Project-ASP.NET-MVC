namespace H8QMedia.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using H8QMedia.Web.Controllers;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class KendoAdminGridBaseController : BaseController
    {
        protected ContentResult GridOperationBigQueryable<T>(IQueryable<T> data, [DataSourceRequest] DataSourceRequest request)
        {
            var serializer = new JavaScriptSerializer();
            var result = new ContentResult();
            serializer.MaxJsonLength = int.MaxValue;
            var dataToShow = data.ToList();
            result.Content = serializer.Serialize(dataToShow.ToDataSourceResult(request));
            result.ContentType = "application/json";

            return result;
        }

        protected JsonResult GridOperationObject<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }
    }
}
