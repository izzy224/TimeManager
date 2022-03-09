using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdWallet { get; set; }
        public Wallet Wallet { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public int IdTransactionCategory { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
    }
}
