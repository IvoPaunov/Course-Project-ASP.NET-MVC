namespace H8QMedia.Data.Models
{
    using H8QMedia.Data.Common.Models;

    public class SellingItem : InteractiveEntity
    {
        public decimal PriceBGN { get; set; }

        public int Availability { get; set; }

        public string SellerId { get; set; }

        public ApplicationUser Seller { get; set; }
    }
}
