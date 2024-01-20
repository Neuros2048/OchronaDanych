using Bankowosc.Server.encription;
using Bankowosc.Server.Entities;
using Bankowosc.Server.Entities.encryptEntities;

namespace Bankowosc.Server.Models;

public class Seeder
{
    public static List<User> GenerateUsers()
    {
        return  new List<User>
        {
            EncryptUser.Encrypt(
            new User
            {
                Id = 1,
                Username = "user1",
                PasswordHash = "$2a$16$9y7PkkwBhYZC3KaQuB2AM.1w47pi69/cckSr6LRkl4D3gM8kCajFa",
                Email = "user1@example.com",
                PhoneNumber = "1234567890",
                ClientNumber = "4732129813",
                Pesel = "94022239261",
                Iv = cipher.GetRandomBytes(16),
                DateCreated = DateTime.Now
            }),
            EncryptUser.Encrypt(
            new User
            {
                Id = 2,
                Username = "user2",
                PasswordHash = "$2a$16$etnQx9rN9xWFZvyPmloOSeRua0.sXjMiIMyf5dAfBGckfs3Fo.a8e",
                Email = "user2@example.com",
                PhoneNumber = "9876543210",
                ClientNumber = "3718005120",
                Pesel = "04222571384",
                Iv = cipher.GetRandomBytes(16),
                DateCreated = DateTime.Now
            }),
            EncryptUser.Encrypt(
            new User
            {
                Id = 3,
                Username = "user3",
                PasswordHash = "$2a$16$Uh3cuvQzs3oe60TzDDR9q.Zli525RGU5rtyDLDoIRI7vrK6ogVWZG",
                Email = "user3@example.com",
                PhoneNumber = "5555555555",
                ClientNumber = "9381230124",
                Pesel = "05312414343",
                Iv = cipher.GetRandomBytes(16),
                DateCreated = DateTime.Now
            })
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
            EncryptCreditCard.Encrypt(
            new CreditCard
            {
                Id = 1,
                Numbers = "5541767398786680",
                SpecialNumber = "522",
                Name = "Jakub Wysocki",
                EndDate = "11/2030",
                Pin = "$2a$16$AtVSqRtjtQPvgVZkQeEsL.DNZ/af6uE7khAw49.q75tI41sKqpaNq", //"3341"
                Iv = cipher.GetRandomBytes(16),
                AcountId = 1,
            }),
            EncryptCreditCard.Encrypt(new CreditCard
            {
                Id = 2,
                Numbers = "5541762873150411",
                SpecialNumber = "972",
                Name = "Piotr Wysocki",
                EndDate = "03/2024",
                Pin ="$2a$16$VOxlSpEafYjbrBISipCazOPhYQng/hZvkE8EWyDCcP4rTEkFu5b8O" , //"5136"
                Iv = cipher.GetRandomBytes(16),
                AcountId = 2,
            }),
            EncryptCreditCard.Encrypt(new CreditCard
            {
                Id = 3,
                Numbers = "5541763721941795",
                SpecialNumber = "827",
                Name = "Szymon Szmigiel",
                EndDate = "11/2026",
                Pin ="$2a$16$.VvJNl6dTawR3kWGcvj4GejYNOIsyuecVNOOlMJL5Z/GqTFpGziSC", //"3881"
                Iv = cipher.GetRandomBytes(16),
                AcountId = 3,
            }),
        };
    }
    
    
}