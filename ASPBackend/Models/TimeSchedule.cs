using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBackend.Models
{
    public class TimeSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeScheduleId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public int ManagementEntityId { get; set; }
        public ManagementEntity ManagementEntity { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; } 
    }
}
