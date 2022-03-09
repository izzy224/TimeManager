namespace ASPBackend.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        IEnumerable<User> Users { get; set; }
        public UserRole()
        {
            Users = new List<User>();
        }
    }
}
