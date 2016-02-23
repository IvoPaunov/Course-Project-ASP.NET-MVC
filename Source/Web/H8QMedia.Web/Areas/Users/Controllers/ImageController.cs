namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Controllers;

    [Authorize]
    public class ImageController : BaseController
    {
        private readonly IImagesService images;

        public ImageController(IImagesService images)
        {
            this.images = images;
        }

        // [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            this.images.Delete(id);

            return this.Json(id);
        }
    }
}
