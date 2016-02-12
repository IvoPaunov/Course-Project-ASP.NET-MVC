namespace H8QMedia.Data.Models
{
    using H8QMedia.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
