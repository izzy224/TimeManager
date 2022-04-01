using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class TransactionCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionCategoryId { get; set; }
        [Required]
        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }

        public TransactionCategory()
        {
            Transactions = new List<Transaction>();
        }
    }
}
