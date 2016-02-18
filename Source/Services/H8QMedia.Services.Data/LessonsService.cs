namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class LessonsService : ILessonsService
    {
        private readonly IDbRepository<Lesson, int> lessons;

        public LessonsService(IDbRepository<Lesson, int> lessons)
        {
            this.lessons = lessons;
        }

        public IQueryable<Lesson> GetById(int id)
        {
            return this.lessons.All()
                            .Where(x => x.Id == id);
        }

        public IQueryable<Lesson> GetAll()
        {
            var result = this.lessons.All()
                                .OrderByDescending(x => x.CreatedOn);

            return result;
        }

        public IQueryable<Lesson> GetByTrainerId(string userId)
        {
            return this.lessons.All()
                            .Where(x => x.TrainerId == userId)
                            .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<Lesson> GetByCourseId(int courseId)
        {
            return this.lessons.All()
                          .Where(x => x.CourseObjective.CourseId == courseId)
                          .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<Lesson> GetByCourseObjectiveId(int courseObjectiveId)
        {
            return this.lessons.All()
                          .Where(x => x.CourseObjectiveId == courseObjectiveId)
                          .OrderByDescending(x => x.CreatedOn);
        }

        public int Create(Lesson lesson)
        {
            this.lessons.Add(lesson);

            this.lessons.Save();

            return lesson.Id;
        }

        public void Update(int id, Lesson lesson)
        {
            throw new System.NotImplementedException();
        }

        public void AddToCourseObjective(int id, int courseObjectiveId)
        {
            var lesson = this.lessons.GetById(id);

            lesson.CourseObjectiveId = courseObjectiveId;

            this.lessons.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.lessons.GetById(id);

            if (entityToDelete != null)
            {
                this.lessons.Delete(entityToDelete);
                this.lessons.Save();
            }
        }
    }
}
