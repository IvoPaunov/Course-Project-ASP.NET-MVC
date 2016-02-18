namespace H8QMedia.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using H8QMedia.Web.Controllers;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class KendoAdminGridBaseController : BaseController
    {
        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
    }
}