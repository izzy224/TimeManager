using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class TransactionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TransactionCategory> TransactionCategories { get; set; }
        public TransactionType()
        {
            TransactionCategories = new List<TransactionCategory>();
        }
    }
}
