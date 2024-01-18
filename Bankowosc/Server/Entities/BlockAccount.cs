namespace Bankowosc.Server.Entities;

public class BlockAccount
{
    public long Id { get; set; }
    public string UserNumber { get; set; }
    public int LoginAttempts { get; set; }
    public DateTime LastLogin { get; set; }
}