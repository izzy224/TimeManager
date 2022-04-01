using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class ToDoStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoStatusId { get; set; }
        public string Name { get; set; }
        public virtual List<ToDo> Todos { get; set; }
        public ToDoStatus()
        {
            Todos = new List<ToDo>();
        }
    }
}
