namespace H8QMedia.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using H8QMedia.Common;
    using H8QMedia.Web.Controllers;

    [Authorize(Roles = ApplicationRoles.Admin)]
    public class ArtController : BaseController
    {
        // GET: Admin/Art
        public ActionResult Index()
        {
            return this.View();
        }
    }
}