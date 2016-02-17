namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using H8QMedia.Common;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.ViewModels.Image;

    [Authorize]
    public class ImageController : BaseController
    {
        private readonly IImagesService images;

        public ImageController(IImagesService images)
        {
            this.images = images;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            this.images.Delete(id);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}