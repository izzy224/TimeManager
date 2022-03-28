using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class ManagementEntityRepository : GenericRepository<ManagementEntity>, IManagementEntityRepository
    {
        public ManagementEntityRepository(DataContext _context) : base(_context)
        {
        }

        public async Task<ManagementEntity> GetManagementEntityByDate(DateTime date, int userId)
        {
            var res = await Context.ManagementEntities.Where(x => x.Date == date && x.UserId==userId).FirstOrDefaultAsync();
            if( res == null)
            {
                ManagementEntity entity = new ManagementEntity() { Date = date, UserId = userId };
                await Insert(entity);
                return entity;
            }
            return res;
        }
    }
}
