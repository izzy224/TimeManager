using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class TransactionTypeRepository : GenericRepository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(DataContext _context) : base(_context)
        {
        }
    }
}
