using ASPBackend.Controllers.Utility;

namespace ASPBackend.Models.Utility
{
    public class UpdateTransaction
    {
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int TransactionCategoryId { get; set; }
    }
}
