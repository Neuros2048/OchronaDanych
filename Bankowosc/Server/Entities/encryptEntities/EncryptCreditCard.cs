using Bankowosc.Server.encription;

namespace Bankowosc.Server.Entities.encryptEntities;

public class EncryptCreditCard
{
    private static string k1 = "c-$XkuM9H+tvtqx4#CzvNExD=gAXwGC4";
    private static string k2 = "ruwpyYb7mXSjMS-URFNKruAp+TMHhd6Z";
    private static string k3 = "zwDMyBcSPWhxDkK3se52D-=QPQUrRG=F";
    private static string k4 = "U@S6&v@cAkSz$P?#NyQch@Cc+=pc=8t@";

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