namespace ASPBackend.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public int IdManagementEntity { get; set; }
        public ManagementEntity ManagementEntity { get; set; }
        public int IdToDoStatus { get; set; }
        public ToDoStatus ToDoStatus { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
