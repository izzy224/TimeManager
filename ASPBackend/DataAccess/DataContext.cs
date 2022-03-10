using ASPBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ManagementEntity> ManagementEntities { get; set; }
        public DbSet<TimeSchedule> TimeSchedules { get; set; }
        public DbSet<ToDo> Todos { get; set; }
        public DbSet<ToDoStatus> ToDoStatuses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
