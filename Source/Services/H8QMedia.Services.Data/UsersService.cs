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

        public IQueryable<ApplicationUser> UserById(string id)
        {
            return this.users
                 .All()
                 .Where(x => x.Id == id);
        }
    }
}
