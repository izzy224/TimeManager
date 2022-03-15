using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class ToDoStatusRepository : GenericRepository<ToDoStatus>, IToDoStatusRepository
    {
        public ToDoStatusRepository(DataContext _context) : base(_context)
        {
        }
    }
}
