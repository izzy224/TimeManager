using ASPBackend.DataAccess.Repositories.Interfaces;
using ASPBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(DataContext _context) : base(_context)
        {
        }
        public async Task<Wallet> GetFirstAsync(int userid)
        {
            var x = await Context.Wallets.FirstOrDefaultAsync(x => x.UserId == userid);
            if (x == null)
            {
                var newWallet = new Wallet() { CurrencyId=3, UserId=userid};
                await Insert(newWallet);
                return newWallet;
            }
            return x;
        }
    }
}
