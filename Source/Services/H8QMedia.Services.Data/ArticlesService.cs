namespace H8QMedia.Services.Data
{
    using System.Linq;

    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class ArticlesService : IArticlesService
    {
        private readonly IDbRepository<Article, int> articles;

        public ArticlesService(IDbRepository<Article, int> articles)
        {
            this.articles = articles;
        }

        public IQueryable<Article> GetById(int id)
        {
            return this.articles.All()
                .Where(x => x.Id == id);
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All().OrderByDescending(x => x.CreatedOn);
        }

        public int Create(string title, string description, string authorId)
        {
            var newEntity = new Article()
            {
                Title = title,
                Description = description,
                AuthorId = authorId
            };

            this.articles.Add(newEntity);

            this.articles.Save();

            return newEntity.Id;
        }

        public int Create(Article article)
        {
            this.articles.Add(article);

            this.articles.Save();

            return article.Id;
        }

        public void Update(int id, string title, string description)
        {
            var entityToUpdate = this.articles.GetById(id);

            entityToUpdate.Title = title;
            entityToUpdate.Description = description;

            this.articles.Save();
        }

        public void Destroy(int id)
        {
            var entityToDelete = this.articles.GetById(id);

            if (entityToDelete != null)
            {
                this.articles.Delete(entityToDelete);
                this.articles.Save();
            }
        }
    }
}
