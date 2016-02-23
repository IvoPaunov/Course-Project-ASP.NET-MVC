namespace H8QMedia.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult Error404()
        {
            return this.View();
        }

        public ActionResult Error500()
        {
            return this.View();
        }

        public ActionResult Error400()
        {
            return this.View();
        }
    }
}