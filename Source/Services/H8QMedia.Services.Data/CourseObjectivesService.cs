namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class CourseObjectivesService : ICourseObjectivesService
    {
        private readonly IDbRepository<CourseObjective, int> objectives;

        public CourseObjectivesService(IDbRepository<CourseObjective, int> objectives)
        {
            this.objectives = objectives;
        }

        public IQueryable<CourseObjective> GetById(int id)
        {
            return this.objectives.All()
             .Where(x => x.Id == id);
        }

        public IQueryable<CourseObjective> GetAll()
        {
            var result = this.objectives.All()
          .OrderByDescending(x => x.CreatedOn);

            return result;
        }

        public IQueryable<CourseObjective> GetByCreatorId(string userId)
        {
            return this.objectives.All()
               .Where(x => x.CreatorId == userId)
               .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<CourseObjective> GetByCourseId(int courseId)
        {
            return this.objectives.All()
            .Where(x => x.CourseId == courseId)
            .OrderByDescending(x => x.CreatedOn);
        }

        public int Create(CourseObjective objective)
        {
            this.objectives.Add(objective);

            this.objectives.Save();

            return objective.Id;
        }

        public void Update(int id, CourseObjective objective)
        {
            var entityToUpdate = this.objectives.GetById(id);

            entityToUpdate.Name = objective.Name;
            entityToUpdate.Description = objective.Description;
            entityToUpdate.Lessons = objective.Lessons;

            this.objectives.Save();
        }

        public void AddToCourse(int courseId, int objectiveId)
        {
            var objective = this.objectives.GetById(objectiveId);

            objective.CourseId = courseId;

            this.objectives.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.objectives.GetById(id);

            if (entityToDelete != null)
            {
                this.objectives.Delete(entityToDelete);
                this.objectives.Save();
            }
        }
    }
}
