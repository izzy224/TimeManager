using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [ForeignKey("UserRole")]
        public int UserRoleId { get; set; }
        [Required, MinLength(4), MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MinLength(6), MaxLength(30)]
        [JsonIgnore]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(30)]
        public string Surname { get; set; }
        public virtual UserRole? UserRole { get; set; }
        public virtual IEnumerable<ManagementEntity> ManagementEntities { get; set; }
        public User()
        {
            ManagementEntities = new List<ManagementEntity>();
            UserRole = new UserRole();
        }
    }
}
