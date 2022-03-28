using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Interfaces
{
    public interface IToDoRepository : IGenericRepository<ToDo>
    {
        public Task<List<ToDo>> GetAllByManagementEntity(int manEntId);
    }
}
