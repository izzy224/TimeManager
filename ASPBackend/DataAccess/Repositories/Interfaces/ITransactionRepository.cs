using ASPBackend.Models;
using ASPBackend.Models.Utility;

namespace ASPBackend.DataAccess.Repositories.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        public Task<List<Transaction>> GetByDate(DateTime date, int lastDays, int walletId);
        public Task<List<TransactionStat>> GetStat(DateTime date, int lastDays, int walletId);
        public Task<MonthlyStat> GetMonthlyStat(DateTime date, int walletId);
    }
}
