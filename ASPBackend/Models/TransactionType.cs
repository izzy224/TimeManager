using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class TransactionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<TransactionCategory> TransactionCategories { get; set; }
        public TransactionType()
        {
            TransactionCategories = new List<TransactionCategory>();
        }
    }
}
