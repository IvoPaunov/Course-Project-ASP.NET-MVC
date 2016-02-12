namespace H8QMedia.Data.Common
{
    public class ValidationConstants
    {
        // User
        public const int MaxUserUserNameLength = 64;

        // Comment
        public const int MinCommentContentLength = 2;
        public const int MaxCommentContentLength = 512;

        // File
        public const int MaxOriginalFileNameLength = 255;
        public const int MaxFileExtensionLength = 4;

        // Error messages
        public const string MinLengthErrorMessage = "The {0} field must be at least {1} characters long";
        public const string MaxLengthErrorMessage = "The {0} field cannot be more than {1} characters long";
        public const string UrlErrorMessage = "The {0} field is not a valid URL";
        public const string CommaSeparatedCollectionLengthErrorMessage = "The {0} field must have between {1} and {2} entries";
        public const string InvalidFileErrorMessage = "The {0} contains invalid file extension or size (between {1}KB and {2}MB)";
        public const string InvalidUpdatedImagesErrorMessage = "Updated images have invalid URLs.";
    }
}
