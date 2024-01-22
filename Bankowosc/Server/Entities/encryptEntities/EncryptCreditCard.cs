using System.Runtime.CompilerServices;
using Bankowosc.Server.encription;

namespace Bankowosc.Server.Entities.encryptEntities;

public class EncryptCreditCard
{
    private static string k1 ;
    private static string k2 ;
    private static string k3 ;
    private static string k4 ;

    public EncryptCreditCard()
    {
        
    }

    public static void SetKey(string k1, string k2, string k3, string k4)
    {
        EncryptCreditCard.k1 = k1;
        EncryptCreditCard.k2 = k2;
        EncryptCreditCard.k3 = k3;
        EncryptCreditCard.k4 = k4;
    }
    public class CardKeys
    {
        public static string k1 { get; set; }
        public static string k2 { get; set; }
        public static string k3 { get; set; }
        public static string k4 { get; set; }
    }
    public static CreditCard Dencrypt(CreditCard creditCard)
    {
        return new CreditCard
        {
            Id = creditCard.Id,
            Numbers = cipher.Decrypt(creditCard.Numbers, k1, creditCard.Iv),
            SpecialNumber = cipher.Decrypt(creditCard.SpecialNumber, k2, creditCard.Iv),
            Name = cipher.Decrypt(creditCard.Name, k3, creditCard.Iv),
            EndDate = cipher.Decrypt(creditCard.EndDate, k4, creditCard.Iv),
            Pin = creditCard.Pin,
            Iv = creditCard.Iv,
            AcountId = creditCard.AcountId,
        };
    }

    public static CreditCard Encrypt(CreditCard creditCard)
    {
        return new CreditCard
        {
            Id = creditCard.Id,
            Numbers = cipher.Encrypt(creditCard.Numbers, k1, creditCard.Iv),
            SpecialNumber = cipher.Encrypt(creditCard.SpecialNumber, k2, creditCard.Iv),
            Name = cipher.Encrypt(creditCard.Name, k3, creditCard.Iv),
            EndDate = cipher.Encrypt(creditCard.EndDate, k4, creditCard.Iv),
            Pin = creditCard.Pin,
            Iv = creditCard.Iv,
            AcountId = creditCard.AcountId,
        };
    }
}