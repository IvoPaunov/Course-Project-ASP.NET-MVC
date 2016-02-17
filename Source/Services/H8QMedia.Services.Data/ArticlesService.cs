﻿namespace H8QMedia.Services.Data
{
    using System.Linq;

    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Common.Extensions;

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
            var result = this.articles.All()
                .OrderByDescending(x => x.CreatedOn);

            return result.AsQueryable();
        }

        public IQueryable<Article> GetByUserId(string userId)
        {
            return this.articles.All()
                .Where(x => x.AuthorId == userId)
                .OrderByDescending(x => x.CreatedOn);
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

        public void Update(int id, Article article)
        {
            var entityToUpdate = this.articles.GetById(id);

            entityToUpdate.Title = article.Title;
            entityToUpdate.Description = article.Description;
            entityToUpdate.Images = article.Images;

            this.articles.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.articles.GetById(id);

            if (entityToDelete != null && entityToDelete.AuthorId == userId)
            {
                this.articles.Delete(entityToDelete);
                this.articles.Save();
            }
        }
    }
}
