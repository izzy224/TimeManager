using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoId { get; set; }
        [Required]
        [ForeignKey("ManagementEntity")]
        public int ManagementEntityId { get; set; }
        public virtual ManagementEntity ManagementEntity { get; set; }
        [Required]
        [ForeignKey("ToDoStatus")]
        public int ToDoStatusId { get; set; }
        public virtual  ToDoStatus ToDoStatus { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public ToDo()
        {
            ToDoStatus = new ToDoStatus();
            ManagementEntity = new ManagementEntity();
        }
    }
}
