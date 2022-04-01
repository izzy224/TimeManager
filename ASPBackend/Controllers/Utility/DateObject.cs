namespace ASPBackend.Controllers.Utility
{
    public class DateObject
    {
        public string Date { get; set; }

        public DateTime GetDate()
        {
            return Convert.ToDateTime(this.Date);
        }
    }
}
