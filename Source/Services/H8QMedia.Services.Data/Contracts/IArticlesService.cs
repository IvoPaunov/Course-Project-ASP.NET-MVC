namespace H8QMedia.Services.Data.Contracts
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface IArticlesService
    {
        IQueryable<Article> GetById(int id);

        IQueryable<Article> GetAll();

        int Create(string title, string description, string authorId);

        int Create(Article article);

        void Update(int id, string title, string description);

        void Destroy(int id);
    }
}
