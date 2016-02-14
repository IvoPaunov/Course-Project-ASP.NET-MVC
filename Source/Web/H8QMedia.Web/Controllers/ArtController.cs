namespace H8QMedia.Web.Controllers
{
    using System.Web.Mvc;

    public class ArtController : BaseController
    {
        // GET: Public/Art
        public ActionResult Index()
        {
            return this.View();
        }
    }
}