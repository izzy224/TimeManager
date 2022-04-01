using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        [Required]
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public int TransactionCategoryId { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
    }
}
