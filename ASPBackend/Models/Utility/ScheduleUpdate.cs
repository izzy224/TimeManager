namespace ASPBackend.Models.Utility
{
    public class ScheduleUpdate
    {
        public int TimeScheduleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime GetStartTime()
        {
            return Convert.ToDateTime(StartTime);
        }
        public DateTime GetEndTime()
        {
            return Convert.ToDateTime(EndTime);
        }
    }
}
