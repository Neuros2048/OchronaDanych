namespace Bankowosc.Server.Entities
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string AccountNumberSender { get; set; }
        public string AccountNumberReceiver { get; set; }
        public decimal Money { get; set; }
        public byte [ ] Iv { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        
        public Account AccountSender { get; set; }
        public long AcountSenderId { get; set; }
        
        public Account AccountReceiver { get; set; }
        public long AcountReceiverId { get; set; }
        
    }
}
