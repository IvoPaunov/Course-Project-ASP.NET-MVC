namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDbRepository<Category, int> categories;

        public CategoriesService(IDbRepository<Category, int> categories)
        {
            this.categories = categories;
        }


        public IQueryable<Category> All()
        {
            return this.categories.All();
        }

        public Category Create(Category categoryToAdd)
        {
            this.categories.Add(categoryToAdd);
            this.categories.Save();

            return categoryToAdd;
        }

        public Category Update(int id, string newName)
        {
            var entityToUpdate = this.categories.GetById(id);

            entityToUpdate.Name = newName;

            this.categories.Save();

            return entityToUpdate;
        }
    }
}
