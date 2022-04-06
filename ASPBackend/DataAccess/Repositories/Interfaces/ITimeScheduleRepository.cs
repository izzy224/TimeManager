using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Interfaces
{
    public interface ITimeScheduleRepository : IGenericRepository<TimeSchedule>
    {
        public Task<List<TimeSchedule>> GetByManagementEntityAsync(int managementEntityId);
    }
}
