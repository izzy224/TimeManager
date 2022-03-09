namespace ASPBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public int IdUserRole { get; set; }
        public UserRole UserRole { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //TODO: Add collections here
        public List<ManagementEntity> ManagementEntities { get; set; }
        
    }
}
