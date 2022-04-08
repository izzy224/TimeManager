using ASPBackend.Models;

namespace ASPBackend.DataAccess.Repositories.Interfaces
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        public Task<Wallet> GetFirstAsync(int userid);
    }
}
