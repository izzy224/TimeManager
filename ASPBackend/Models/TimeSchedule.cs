namespace ASPBackend.Models
{
    public class TimeSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdManagementEntity { get; set; }
        public ManagementEntity ManagementEntity { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; } 
    }
}
