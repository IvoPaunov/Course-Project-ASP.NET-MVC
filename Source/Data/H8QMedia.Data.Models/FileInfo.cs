namespace H8QMedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using H8QMedia.Data.Common;
    using H8QMedia.Data.Common.Models;

    public abstract class FileInfo : BaseModel<int>
    {
        [Required]
        [MaxLength(ValidationConstants.MaxOriginalFileNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string OriginalFileName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxFileExtensionLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string FileExtension { get; set; }

        public string UrlPath { get; set; }
    }
}
