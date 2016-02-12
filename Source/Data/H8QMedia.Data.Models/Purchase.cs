﻿namespace H8QMedia.Data.Models
{
    using System.Collections.Generic;

    using H8QMedia.Data.Common.Models;

    public class Purchase : BaseModel<int>
    {
        private ICollection<SellingItem> items;

        public Purchase()
        {
            this.items = new HashSet<SellingItem>();
        }

        public PurchaseStatus Status { get; set; }

        public string Comment { get; set; }

        public string BuyerId { get; set; }

        public virtual ApplicationUser Buyer { get; set; }

        public string SellerId { get; set; }

        public virtual ApplicationUser Seller { get; set; }

        public virtual ICollection<SellingItem> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
    }
}
