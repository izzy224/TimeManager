using ASPBackend.Controllers.Utility;

namespace ASPBackend.Models.Utility
{
    public class TransactionPostDTO
    {
        public string Date { get; set; }

        public DateTime GetDate()
        {
            return Convert.ToDateTime(this.Date);
        }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int TransactionCategoryId { get; set; }
        public int WalletId { get; set; }
    }
}
