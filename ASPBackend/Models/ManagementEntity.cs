namespace ASPBackend.Models
{
    public class ManagementEntity
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public DateOnly Date { get; set; }
    }
}
