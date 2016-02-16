namespace H8QMedia.Web.Infrastructure.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Web;

    public class ValidateFilesCollectionAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var files = value as IEnumerable<HttpPostedFileBase>;

            foreach (var file in files)
            {
                if (file != null)
                {
                    if (file.ContentLength > 1 * 1024 * 1024)
                    {
                        return false;
                    }

                    try
                    {
                        using (var img = Image.FromStream(file.InputStream))
                        {
                            bool isValidFormat = img.RawFormat.Equals(ImageFormat.Jpeg) ||
                                                 img.RawFormat.Equals(ImageFormat.Png);

                            if (!isValidFormat)
                            {
                                return false;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return true;
        }
    }
}
