using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class Currency
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(5)]
        public string Symbol { get; set; }
        public IEnumerable<Wallet> Wallets { get; set; }

        public Currency()
        {
            Wallets = new List<Wallet>();
        }
    }
}
