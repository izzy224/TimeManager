using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class TimeScheduleRepository : GenericRepository<TimeSchedule>, ITimeScheduleRepository
    {
        public TimeScheduleRepository(DataContext _context) : base(_context)
        {
        }
    }
}
