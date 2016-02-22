namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<ApplicationUser, string> users;

        public UsersService(IDbRepository<ApplicationUser, string> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetUser(string name)
        {
            return this.users
                     .All()
                     .Where(x => x.UserName == name);
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<ApplicationUser> UserById(string id)
        {
            return this.users
                 .All()
                 .Where(x => x.Id == id);
        }

        public IQueryable<ApplicationUser> AddToRole(string iduserId, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ApplicationUser> RemoveFromRole(string iduserId, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public void Destroy(string userId)
        {
            var userToDedlete = this.users.GetById(userId);

            this.users.Delete(userToDedlete);
            this.users.Save();
        }
    }
}
