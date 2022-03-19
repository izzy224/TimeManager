using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class ToDo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoId { get; set; }
        public int ManagementEntityId { get; set; }
        public  ManagementEntity ManagementEntity { get; set; }
        public int IdToDoStatus { get; set; }
        public  ToDoStatus ToDoStatus { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
    }
}
