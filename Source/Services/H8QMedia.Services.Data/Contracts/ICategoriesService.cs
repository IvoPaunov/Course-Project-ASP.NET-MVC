namespace H8QMedia.Services.Data.Contracts
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> All();

        Category Create(Category categoryToAdd);

        Category Update(int id, string newName);
    }
}
