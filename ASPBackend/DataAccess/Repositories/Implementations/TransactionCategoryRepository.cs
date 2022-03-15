using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class TransactionCategoryRepository : GenericRepository<TransactionCategory>, ITransactionCategoryRepository
    {
        public TransactionCategoryRepository(DataContext _context) : base(_context)
        {
        }
    }
}
