using Bankowosc.Server.Entities.Enumerations;

namespace Bankowosc.Server.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; } = Role.USER;
        
        public string ClientNumber { get; set; }
        public byte[] Iv { get; set; }
        public string Pesel { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        
        public Account Account { get; set; }
    }
}
