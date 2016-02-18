namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class CoursesService : ICoursesService
    {
        public IQueryable<Course> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Course> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Course> GetByUserId(string userId)
        {
            throw new System.NotImplementedException();
        }

        public int Create(Course course)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Course course)
        {
            throw new System.NotImplementedException();
        }

        public void Destroy(int id, string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
