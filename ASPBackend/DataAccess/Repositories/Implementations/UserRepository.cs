using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using ASPBackend.Models.Utility;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext _context) : base(_context)
        {
            _context.Users.Include(x => x.UserRole).ToList();
        }

        public async Task CreateUserAsync(User user)
        {
            await Insert(user);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> ValidateUser(UserLogin userLogin)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == userLogin.Username.ToLower() && u.Password.Equals(userLogin.Password));
        }
    }
}
