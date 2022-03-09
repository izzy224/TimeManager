﻿namespace ASPBackend.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdCurrency { get; set; }
        public Currency Currency { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public Wallet()
        {
            Transactions = new List<Transaction>();
        }
    }
}