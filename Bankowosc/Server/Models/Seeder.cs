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
                PasswordHash = "$2a$11$/mb61PYFJRcQwpgGyR089ujK0CZEBjQwKKX0unXoZbZVTYG/WW3Jm",
                Email = "user1@example.com",
                PhoneNumber = "1234567890",
                ClientNumber = "4732129813",
                PeselHash = "a",
                DateCreated = DateTime.Now
            },
            new User
            {
                Id = 2,
                Username = "user2",
                PasswordHash = "$2a$11$aXmxeKeEc.YAJ.xVyv2TReQAPiqIArKtUO7OFJ1QSxpP2Bn.IpPKq",
                Email = "user2@example.com",
                PhoneNumber = "9876543210",
                ClientNumber = "3718005120",
                PeselHash = "a",
                DateCreated = DateTime.Now
            },
            new User
            {
                Id = 3,
                Username = "user3",
                PasswordHash = "$2a$11$nasG4aM4pQbOM.Rq4i1FBejdUhYEfXwrifah0xwMgffhwmshn.Z/.",
                Email = "user3@example.com",
                PhoneNumber = "5555555555",
                ClientNumber = "9381230124",
                PeselHash = "a",
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

    public static List<CreditCard> GenerateCreditCards()
    {
        return new List<CreditCard>()
        {
            new CreditCard
            {
                Id = 1,
                Numbers = "5541767398786680",
                SpecialNumber = "522",
                Name = "Jakub Wysocki",
                EndDate = "11/2030",
                Pin = "3341",
                AcountId = 1,
            },new CreditCard
            {
                Id = 2,
                Numbers = "5541762873150411",
                SpecialNumber = "972",
                Name = "Piotr Wysocki",
                EndDate = "03/2024",
                Pin = "5136",
                AcountId = 2,
            },new CreditCard
            {
                Id = 3,
                Numbers = "5541763721941795",
                SpecialNumber = "827",
                Name = "Szymon Szmigiel",
                EndDate = "11/2026",
                Pin = "3881",
                AcountId = 3,
            },
        };
    }
    
    
}