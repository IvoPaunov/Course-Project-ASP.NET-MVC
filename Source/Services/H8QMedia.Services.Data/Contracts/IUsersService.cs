namespace H8QMedia.Services.Data.Contracts
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface IUsersService
    {
        IQueryable<ApplicationUser> GetUser(string name);

        IQueryable<ApplicationUser> GetAll();

        IQueryable<ApplicationUser> UserById(string id);

        IQueryable<ApplicationUser> AddToRole(string iduserId, string roleName);

        IQueryable<ApplicationUser> RemoveFromRole(string iduserId, string roleName);

        void Destroy(string userId);
    }
}
