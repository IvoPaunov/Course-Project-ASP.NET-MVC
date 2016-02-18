namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class LessonsService : ILessonsService
    {
        public IQueryable<Lesson> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Lesson> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Lesson> GetByTrainerId(string userId)
        {
            throw new System.NotImplementedException();
        }

        public int Create(Lesson lesson)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Lesson lesson)
        {
            throw new System.NotImplementedException();
        }

        public void Destroy(int id, string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
