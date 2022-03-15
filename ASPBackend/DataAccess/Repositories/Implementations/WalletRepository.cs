using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(DataContext _context) : base(_context)
        {
        }
    }
}
