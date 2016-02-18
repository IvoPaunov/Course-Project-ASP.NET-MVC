namespace H8QMedia.Web.ViewModels.Shop
{
    using System.Collections.Generic;

    using H8QMedia.Web.ViewModels.Common;
    using H8QMedia.Web.ViewModels.SellingItem;

    public class ShopIndexViewModel
    {
        public PaginationViewModel PaginationModel { get; set; }

        public IEnumerable<SellingItemViewModel> ItemsForSale { get; set; }
    }
}
