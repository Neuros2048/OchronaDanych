using Bankowosc.Server.Entities.Enumerations;

namespace Bankowosc.Server.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = Role.USER;

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
