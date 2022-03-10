using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class ManagementEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUser { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
