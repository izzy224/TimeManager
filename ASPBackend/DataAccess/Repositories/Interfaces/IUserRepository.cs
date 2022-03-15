using ASPBackend.Models;
using ASPBackend.Models.Utility;

namespace ASPBackend.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> ValidateUser(UserLogin userLogin);
        Task CreateUserAsync(User user);
    }
}
