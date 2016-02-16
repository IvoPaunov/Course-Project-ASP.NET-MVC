namespace H8QMedia.Data.Common.Repositories
{
    using System.Linq;
    using H8QMedia.Data.Common.Models;

   // public interface IDbRepository<T> : IDbRepository<T, int>
   //     where T : IAuditInfo, IDeletableEntity, ITKeyEntity<int>
   // {
   // }

    public interface IDbRepository<T, in TKey>
        where T : IAuditInfo, IDeletableEntity, ITKeyEntity<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}
