namespace H8QMedia.Web.Infrastructure.UploadHelpers
{
    using System;
    using System.IO;
    using System.Web;
    using H8QMedia.Web.Infrastructure.Constants;

    public class ImageUplouder
    {
        // TODO: Make it interface and base uploader
        public H8QMedia.Data.Models.Image UploadImage(HttpPostedFileBase file, string folderPath, string userId)
        {
            string originalFilename = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = Guid.NewGuid().ToString() + "." + fileExtension;
            var imagePath = folderPath + "/" + uniqueFileName;
            var imageUrl = WebConstants.ImagesMainPathUrl + userId + "/" + uniqueFileName;

            var image = new H8QMedia.Data.Models.Image();
            image.OriginalFileName = Path.GetFileName(originalFilename);
            image.FileExtension = Path.GetExtension(fileExtension);
            image.UrlPath = imageUrl;

            if (!Directory.Exists(folderPath))
            {
                DirectoryInfo dir = Directory.CreateDirectory(folderPath);
            }

            file.SaveAs(imagePath);

            return image;
        }
    }
}
