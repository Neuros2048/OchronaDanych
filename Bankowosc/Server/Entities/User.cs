using Bankowosc.Server.Entities.Enumerations;

namespace Bankowosc.Server.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; } = Role.USER;
        
        public string ClientNumber { get; set; }
        public byte[] PeselSalt { get; set; }
        public byte[] PeselHash { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        
        public Account Account { get; set; }
    }
}
