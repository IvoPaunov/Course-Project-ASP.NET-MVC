namespace H8QMedia.Data.Common
{
    public class ValidationConstants
    {
        // User
        public const int MaxUserUserNameLength = 64;
        public const int MinUserNameLength = 2;
        public const int MaxUserNameLength = 64;

        // Comment
        public const int MinCommentContentLength = 2;
        public const int MaxCommentContentLength = 512;

        // Country
        public const int MinCountryNameLength = 2;
        public const int MaxCountryNameLength = 64;

        public const int MinCountryCodeLength = 2;
        public const int MaxCountryCodeLength = 2;

        // City
        public const int MinCityNameLength = 2;
        public const int MaxCityNameLength = 64;

        // Category
        public const int MinCategoryNameLength = 2;
        public const int MaxCategoryNameLength = 128;
        public const int MaxCategoryDescriptionLength = 256;

        // InteractiveEntity
        public const int MinInteractiveEntityTitleLength = 2;
        public const int MaxInteractiveEntityTitleLength = 256;
        public const int MaxInteractiveEntityDescriptionLength = 2048;

        // Course Objective
        public const int MinCourseObjectiveNameLength = 2;
        public const int MaxCourseObjectiveNameLength = 256;
        public const int MaxCourseObjectiveDescriptionLength = 1024;

        // File
        public const int MaxOriginalFileNameLength = 255;
        public const int MaxFileExtensionLength = 4;

        // Lesson
        public const int MaxLessonYoutubeVideoIdLength = 64;

        // Message
        public const int MinMessageContentLength = 2;
        public const int MaxMessageContentLength = 2048;

        // UserTypeCategory
        public const int MinUserTypeCategoryNameLength = 2;
        public const int MaxUserTypeCategoryNameLength = 256;

        // Address
        public const int MinAddressLineLength = 2;
        public const int MaxAddressLineLength = 512;
        public const int MinTelephoneNumberLength = 2;
        public const int MaxTelephoneNumberLength = 64;
        public const int MinRecipientNamesLength = 2;
        public const int MaxRecipientNamesLength = 256;

        // Purchase
        public const int MaxPurchaseCommentLength = 512;

        // Error messages
        public const string MinLengthErrorMessage = "The {0} field must be at least {1} characters long";
        public const string MaxLengthErrorMessage = "The {0} field cannot be more than {1} characters long";
        public const string UrlErrorMessage = "The {0} field is not a valid URL";
        public const string CommaSeparatedCollectionLengthErrorMessage = "The {0} field must have between {1} and {2} entries";
        public const string InvalidFileErrorMessage = "The {0} contains invalid file extension or size (between {1}KB and {2}MB)";
        public const string InvalidUpdatedImagesErrorMessage = "Updated images have invalid URLs.";
    }
}
