using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUserRole { get; set; }
        public UserRole UserRole { get; set; }
        [Required]
        [MinLength(4), MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MinLength(6), MaxLength(30)]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Role { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(30)]
        public string Surname { get; set; }

        //TODO: Add collections here
        public List<ManagementEntity> ManagementEntities { get; set; }
        
    }
}
