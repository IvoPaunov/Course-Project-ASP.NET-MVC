namespace H8QMedia.Services.Data.Contracts
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface ICourseObjectivesService
    {
        IQueryable<CourseObjective> GetById(int id);

        IQueryable<CourseObjective> GetAll();

        IQueryable<CourseObjective> GetByCreatorId(string userId);

        IQueryable<CourseObjective> GetByCourseId(int courseId);

        int Create(CourseObjective course);

        void Update(int id, CourseObjective course);

        void AddToCourse(int courseId, int objectiveId);

        void Destroy(int id, string userId);
    }
}
