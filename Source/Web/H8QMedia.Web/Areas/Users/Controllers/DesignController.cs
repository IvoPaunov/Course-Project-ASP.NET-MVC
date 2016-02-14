namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;
    using H8QMedia.Web.Controllers;

    public class DesignController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
