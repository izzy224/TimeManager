using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using ASPBackend.Models.Utility;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DataContext _context) : base(_context)
        {
            _context.Transactions.Include(x => x.TransactionCategory).ToList();
        }
        public async Task<List<Transaction>> GetByDate(DateTime date, int lastDays, int walletId)
        {
            DateTime fromDate = date.AddDays(0-lastDays);
            date = date.AddDays(1);
            var x = await Context.Transactions
                .Where(x => x.WalletId == walletId && 
                DateTime.Compare(fromDate, x.TransactionDate) <= 0
                && DateTime.Compare(date, x.TransactionDate) >= 0).ToListAsync();
            return x;
        }

        public async Task<MonthlyStat> GetMonthlyStat(DateTime date, int walletId)
        {
            MonthlyStat monthlyStat = new MonthlyStat() { Income=0, Spendings=0};
            DateTime fromDate = date.AddDays(0 - 30);
            date = date.AddDays(1);
            var tempStat = await Context.Transactions.Where(x => x.WalletId == walletId &&
                DateTime.Compare(fromDate, x.TransactionDate) <= 0
                && DateTime.Compare(date, x.TransactionDate) >= 0).ToListAsync();
            foreach(var stat in tempStat)
            {
                if(stat.TransactionCategory.TransactionTypeId == 1)
                {
                    monthlyStat.Income += stat.Amount;
                }
                else
                {
                    monthlyStat.Spendings += stat.Amount;
                }
            }
            return monthlyStat;
        }

        public async Task<List<TransactionStat>> GetStat(DateTime date, int lastDays, int walletId)
        {
            List<TransactionStat> stat = new List<TransactionStat>();
            DateTime fromDate = date.AddDays(0 - lastDays);
            date = date.AddDays(1);
            var tempStat = await Context.Transactions.Where(x => x.WalletId == walletId &&
                DateTime.Compare(fromDate, x.TransactionDate) <= 0
                && DateTime.Compare(date, x.TransactionDate) >= 0)
                .Join(Context.TransactionCategories, x => x.TransactionCategoryId, y => y.TransactionCategoryId, (x, y) => new { x.Amount, y.Name })
                .GroupBy(y => y.Name)
                .Select(x => new { Name = x.Key, Amount = x.Select(f => f.Amount).Sum()}).ToListAsync();
            foreach(var x in tempStat)
            {
                stat.Add(new TransactionStat() { Amount = x.Amount, Name = x.Name });
            }
            return stat;
        }
        
    }
}
