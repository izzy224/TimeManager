using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //public DbSet<Table> TableName {get;set}
    }
}
