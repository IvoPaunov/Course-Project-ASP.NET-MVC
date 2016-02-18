namespace H8QMedia.Services.Data.Contracts
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface ILessonsService
    {
        IQueryable<Lesson> GetById(int id);

        IQueryable<Lesson> GetAll();

        IQueryable<Lesson> GetByTrainerId(string userId);

        IQueryable<Lesson> GetByCourseId(int courseId);

        IQueryable<Lesson> GetByCourseObjectiveId(int courseObjectiveId);

        int Create(Lesson lesson);

        void Update(int id, Lesson lesson);

        void AddToCourseObjective(int id, int courseObjectiveId);

        void Destroy(int id, string userId);
    }
}
