using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class TransactionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
