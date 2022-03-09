namespace ASPBackend.Models
{
    public class TransactionCategory
    {
        public int Id { get; set; }
        public int IdTransactionType { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Name { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }

        public TransactionCategory()
        {
            Transactions = new List<Transaction>();
        }
    }
}
