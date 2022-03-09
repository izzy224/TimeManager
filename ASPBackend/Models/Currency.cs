namespace ASPBackend.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public IEnumerable<Wallet> Wallets { get; set; }

        public Currency()
        {
            Wallets = new List<Wallet>();
        }
    }
}
