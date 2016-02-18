namespace H8QMedia.Services.Data.Contracts
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface ISellingItemsService
    {
        IQueryable<SellingItem> GetById(int id);

        IQueryable<SellingItem> GetAll();

        IQueryable<SellingItem> GetByUserId(string userId);

        int Create(string title, string description, string authorId, decimal prise, int availability);

        int Create(SellingItem article);

        void Update(int id, string title, string description, decimal prise, int availability);

        void Update(int id, SellingItem article);

        void Destroy(int id, string userId);
    }
}
