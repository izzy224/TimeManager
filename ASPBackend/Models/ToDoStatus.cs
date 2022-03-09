namespace ASPBackend.Models
{
    public class ToDoStatus
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public List<ToDo> Todos { get; set; }
        public ToDoStatus()
        {
            Todos = new List<ToDo>();
        }
    }
}
