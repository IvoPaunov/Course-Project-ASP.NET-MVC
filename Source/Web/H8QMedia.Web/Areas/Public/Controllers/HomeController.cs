namespace H8QMedia.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;
    using H8QMedia.Web.Controllers;
// using Services.Data;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return this.View("");
        }
    }
}
