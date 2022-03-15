using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class ManagementEntityRepository : GenericRepository<ManagementEntity>, IManagementEntityRepository
    {
        public ManagementEntityRepository(DataContext _context) : base(_context)
        {
        }
    }
}
