namespace H8QMedia.Web.Controllers
{
    using System.Web.Mvc;

// using Services.Data;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
