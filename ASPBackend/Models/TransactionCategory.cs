using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class TransactionCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionCategoryId { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Name { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }

        public TransactionCategory()
        {
            Transactions = new List<Transaction>();
        }
    }
}
