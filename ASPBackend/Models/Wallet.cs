using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class Wallet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public Wallet()
        {
            Transactions = new List<Transaction>();
        }
    }
}
