namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class SellingItemsService : ISellingItemsService
    {
        private readonly IDbRepository<SellingItem, int> items;

        public SellingItemsService(IDbRepository<SellingItem, int> items)
        {
            this.items = items;
        }

        public IQueryable<SellingItem> GetById(int id)
        {
            return this.items.All()
             .Where(x => x.Id == id);
        }

        public IQueryable<SellingItem> GetAll()
        {
            var result = this.items.All()
                .OrderByDescending(x => x.CreatedOn);

            return result.AsQueryable();
        }

        public IQueryable<SellingItem> GetByUserId(string userId)
        {
            return this.items.All()
              .Where(x => x.SellerId == userId)
              .OrderByDescending(x => x.CreatedOn);
        }

        public int Create(string title, string description, string sellerId, decimal price, int availability)
        {
            var newEntity = new SellingItem()
            {
                Title = title,
                Description = description,
                SellerId = sellerId,
                PriceBGN = price,
                Availability = availability
            };

            this.items.Add(newEntity);

            this.items.Save();

            return newEntity.Id;
        }

        public int Create(SellingItem item)
        {
            this.items.Add(item);

            this.items.Save();

            return item.Id;
        }

        public void Update(int id, string title, string description, decimal prise, int availability)
        {
            var entityToUpdate = this.items.GetById(id);

            entityToUpdate.Title = title;
            entityToUpdate.Description = description;
            entityToUpdate.PriceBGN = prise;
            entityToUpdate.Availability = availability;

            this.items.Save();
        }

        public void Update(int id, SellingItem item)
        {
            var entityToUpdate = this.items.GetById(id);

            entityToUpdate.Title = item.Title;
            entityToUpdate.Description = item.Description;
            entityToUpdate.PriceBGN = item.PriceBGN;
            entityToUpdate.Availability = item.Availability;
            entityToUpdate.Images = item.Images;

            this.items.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.items.GetById(id);

            if (entityToDelete != null)
            {
                this.items.Delete(entityToDelete);
                this.items.Save();
            }
        }
    }
}
