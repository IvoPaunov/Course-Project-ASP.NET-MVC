namespace H8QMedia.Data.Common.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using H8QMedia.Data.Common.Models;

    // TODO: Why BaseModel<int> instead BaseModel<TKey>?
    public class DbRepository<T, T2> : IDbRepository<T, T2>
        where T2 : IEquatable<T2>
        where T : class, IAuditInfo, IDeletableEntity, ITKeyEntity<T2>
    {
        public DbRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; }

        private DbContext Context { get; }

        public IQueryable<T> All()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet;
        }

        public T GetById(T2 id)
        {
            return this.All().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
