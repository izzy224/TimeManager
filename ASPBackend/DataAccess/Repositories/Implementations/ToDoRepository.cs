using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class ToDoRepository : GenericRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(DataContext _context) : base(_context)
        {
        }
    }
}
