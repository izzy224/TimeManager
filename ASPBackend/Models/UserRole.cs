using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRoleId { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public IEnumerable<User> Users { get; set; }
        public UserRole()
        {
            Users = new List<User>();
        }
    }
}
