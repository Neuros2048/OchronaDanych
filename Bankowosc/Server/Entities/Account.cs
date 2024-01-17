namespace Bankowosc.Server.Entities
{
    public class Account
    {
        public long Id { get; set; }
        public decimal Money { get; set; }
        public string AccountNumber { get; set; }
        
        public User User { get; set; }
        public long UserId { get; set; }
        public CreditCard CreditCard { get; set; }
        public List<Transaction>? TransactionSend { get; set; }
        public List<Transaction>? TransactionReceived { get; set; }
    }
}
