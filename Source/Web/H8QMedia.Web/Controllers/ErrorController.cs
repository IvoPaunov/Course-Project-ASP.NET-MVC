namespace H8QMedia.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult Error500()
        {
            return View();
        }

        public ActionResult Error400()
        {
            return View();
        }
    }
}