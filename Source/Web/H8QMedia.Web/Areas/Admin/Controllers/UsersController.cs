namespace H8QMedia.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using H8QMedia.Web.Controllers;

    public class UsersController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
