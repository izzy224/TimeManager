using System.Collections.Generic;

namespace ASPBackend.Models.Utility
{
    public class ToDoByStatus
    {
        public ToDoStatus ToDoStatus { get; set; }
        public IEnumerable<ToDo> Todos { get; set; }

        public ToDoByStatus()
        {
            Todos = new List<ToDo>();
        }
    }
}
