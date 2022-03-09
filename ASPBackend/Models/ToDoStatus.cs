using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class ToDoStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Name { get; set; }
        public List<ToDo> Todos { get; set; }
        public ToDoStatus()
        {
            Todos = new List<ToDo>();
        }
    }
}
