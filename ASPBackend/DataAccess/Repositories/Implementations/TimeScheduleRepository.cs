using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class TimeScheduleRepository : GenericRepository<TimeSchedule>, ITimeScheduleRepository
    {
        public TimeScheduleRepository(DataContext _context) : base(_context)
        {
        }

        public async Task<List<TimeSchedule>> GetByManagementEntityAsync(int managementEntityId)
        {
            return await Context.TimeSchedules.Where(x => x.ManagementEntityId == managementEntityId).ToListAsync();
        }
    }
}
