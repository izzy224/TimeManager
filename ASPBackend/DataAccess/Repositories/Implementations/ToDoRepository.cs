using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class ToDoRepository : GenericRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(DataContext _context) : base(_context)
        {

        }

        public async Task<List<ToDo>> GetAllByManagementEntity(int manEntId)
        {
            return await Context.Todos.Where(x => x.ManagementEntityId == manEntId).ToListAsync();
        }

        public async Task<List<ToDo>> GetAllByManagementEntityStatus(int manEntId, int statusId)
        {
            return await Context.Todos.Where(x => x.ManagementEntityId == manEntId && x.ToDoStatusId == statusId).ToListAsync();
        }
    }
}
