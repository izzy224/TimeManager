using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DataContext _context) : base(_context)
        {
        }
    }
}
