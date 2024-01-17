namespace Bankowosc.Server.Entities
{
    public class CreditCard
    {
        public long Id { get; set; }
        public string Numbers { get; set; }
        public string SpecialNumber { get; set; }
        public string Name { get; set; }
        public string EndDate { get; set; }
        
        public long AcountId { get; set; }
        public Account Account { get; set; }
    }
}
