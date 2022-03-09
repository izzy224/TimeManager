namespace ASPBackend.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int IdWallet { get; set; }
        public Wallet Wallet { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public int IdTransactionCategory { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
    }
}
