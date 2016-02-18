namespace H8QMedia.Services.Data.Contracts
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface ICoursesService
    {
        IQueryable<Course> GetById(int id);

        IQueryable<Course> GetAll();

        IQueryable<Course> GetByTrainerId(string userId);

        IQueryable<Course> GetByStudentId(string userId);

        int Create(Course course);

        void Update(int id, Course course);

        void AddTrainerToCourse(int courseId, string userId);

        void Destroy(int id, string userId);
    }
}
