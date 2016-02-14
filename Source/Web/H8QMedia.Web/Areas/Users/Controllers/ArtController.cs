namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;

    using H8QMedia.Common;
    using H8QMedia.Web.Controllers;

    [Authorize(Roles = ApplicationRoles.Artist)]
    public class ArtController : BaseController
    {
        // GET: Public/Art
        public ActionResult Index()
        {
            return this.View();
        }
    }
}