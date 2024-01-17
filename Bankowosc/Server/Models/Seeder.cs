using Bankowosc.Server.Entities;

namespace Bankowosc.Server.Models;

public class Seeder
{
    public static List<User> GenerateUsers()
    {
        return  new List<User>
        {
            new User
            {
                Id = 1,
                Username = "user1",
                PasswordHash = new byte[]
                {
                    /* Password hash bytes */
                },
                PasswordSalt = new byte[]
                {
                    /* Password salt bytes */
                },
                Email = "user1@example.com",
                PhoneNumber = "1234567890",
                ClientNumber = "C123",
                PeselSalt = new byte[]
                {
                    /* Pesel salt bytes */
                },
                PeselHash = new byte[]
                {
                    /* Pesel hash bytes */
                },
                DateCreated = DateTime.Now
            },
            new User
            {
                Id = 2,
                Username = "user2",
                PasswordHash = new byte[]
                {
                    /* Password hash bytes */
                },
                PasswordSalt = new byte[]
                {
                    /* Password salt bytes */
                },
                Email = "user2@example.com",
                PhoneNumber = "9876543210",
                ClientNumber = "C456",
                PeselSalt = new byte[]
                {
                    /* Pesel salt bytes */
                },
                PeselHash = new byte[]
                {
                    /* Pesel hash bytes */
                },
                DateCreated = DateTime.Now
            },
            new User
            {
                Id = 3,
                Username = "user3",
                PasswordHash = new byte[]
                {
                    /* Password hash bytes */
                },
                PasswordSalt = new byte[]
                {
                    /* Password salt bytes */
                },
                Email = "user3@example.com",
                PhoneNumber = "5555555555",
                ClientNumber = "C789",
                PeselSalt = new byte[]
                {
                    /* Pesel salt bytes */
                },
                PeselHash = new byte[]
                {
                    /* Pesel hash bytes */
                },
                DateCreated = DateTime.Now
            }
        };
    }
    
    public static List<Account> GenerateAccounts()
    {
        return new List<Account>
        {
            new Account
            {
                Id = 1,
                Money = 1000.50m, // Replace with your actual money value
                AccountNumber = "11111111111111111111111111",
                UserId = 1
            },
            new Account
            {
                Id = 2,
                Money = 500.75m, // Replace with your actual money value
                AccountNumber = "11111111111111111111111112",
                UserId = 2
            },
            new Account
            {
                Id = 3,
                Money = 2000.30m, // Replace with your actual money value
                AccountNumber = "11111111111111111111111113",
                UserId = 3
            }
        };
    }
    
    
}