namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class CoursesService : ICoursesService
    {
        private readonly IDbRepository<Course, int> courses;
        private readonly IDbRepository<ApplicationUser, string> users;

        public CoursesService(IDbRepository<Course, int> courses, IDbRepository<ApplicationUser, string> users)
        {
            this.courses = courses;
            this.users = users;
        }

        public IQueryable<Course> GetById(int id)
        {
            return this.courses.All()
              .Where(x => x.Id == id);
        }

        public IQueryable<Course> GetAll()
        {
            var result = this.courses.All()
             .OrderByDescending(x => x.CreatedOn);

            return result;
        }

        public IQueryable<Course> GetByTrainerId(string userId)
        {
            return this.courses.All()
              .Where(x => x.Trainers.Any(y => y.Id == userId))
              .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<Course> GetByStudentId(string userId)
        {
            return this.courses.All()
         .Where(x => x.Students.Any(y => y.Id == userId))
         .OrderByDescending(x => x.CreatedOn);
        }

        public int Create(Course course)
        {
            this.courses.Add(course);

            this.courses.Save();

            return course.Id;
        }

        public void Update(int id, Course course)
        {
            var entityToUpdate = this.courses.GetById(id);

            entityToUpdate.Title = course.Title;
            entityToUpdate.Description = course.Description;
            entityToUpdate.Images = course.Images;
            entityToUpdate.Trainers = course.Trainers;
            entityToUpdate.Students = course.Students;

            this.courses.Save();
        }

        public void AddTrainerToCourse(int courseId, string userId)
        {
            var courseToUpdate = this.courses.GetById(courseId);
            var trainer = this.users.GetById(userId);

            courseToUpdate.Trainers.Add(trainer);

            this.courses.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.courses.GetById(id);

            if (entityToDelete != null && entityToDelete.Trainers.Any(x => x.Id == userId))
            {
                this.courses.Delete(entityToDelete);
                this.courses.Save();
            }
        }
    }
}
