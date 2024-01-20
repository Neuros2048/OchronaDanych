using System.Security.Cryptography.Xml;
using Bankowosc.Server.encription;

namespace Bankowosc.Server.Entities.encryptEntities;

public class EncryptTransaction
{
    private static string k1 = "txnB&q4#caKmvBErr2-=88e8!WxV#wGh";
    private static string k2 = "KsUjCb6!d6uUt5G5==+ev4eejHYwuBRu";
    private static string k3 = "8uYxeG#H37pggn5uh#4!4PaqGbJyzxK#";
    private static string k4 = "Wyyu@2nXXd9P?hM5az?!daeQkV$Ym%v$";
    private static string k5 = "MmTjdBd5qAZ933e49NpA3XDGZSm++VWF";

    public static Transaction DecryptTransaction(Transaction transaction)
    {
        return new Transaction
        {
            Id = transaction.Id,
            Title = cipher.Decrypt(transaction.Title, k1, transaction.Iv),
            Sender = cipher.Decrypt(transaction.Sender, k2, transaction.Iv),
            Receiver = cipher.Decrypt(transaction.Receiver, k3, transaction.Iv),
            Money = transaction.Money,
            Iv = transaction.Iv,
            DateTime = transaction.DateTime,
            AccountNumberSender = cipher.Decrypt(transaction.AccountNumberSender, k4, transaction.Iv),
            AccountNumberReceiver = cipher.Decrypt(transaction.AccountNumberReceiver, k5, transaction.Iv),
            AcountSenderId = transaction.AcountSenderId,
            AcountReceiverId = transaction.AcountReceiverId
            
            
        };
    }
    public static Transaction EcryptTransaction(Transaction transaction)
    {
        return new Transaction
        {
            Id = transaction.Id,
            Title = cipher.Encrypt(transaction.Title, k1, transaction.Iv),
            Sender = cipher.Encrypt(transaction.Sender, k2, transaction.Iv),
            Receiver = cipher.Encrypt(transaction.Receiver, k3, transaction.Iv),
            Money = transaction.Money,
            Iv = transaction.Iv,
            DateTime = transaction.DateTime,
            AccountNumberSender = cipher.Encrypt(transaction.AccountNumberSender, k4, transaction.Iv),
            AccountNumberReceiver = cipher.Encrypt(transaction.AccountNumberReceiver, k5, transaction.Iv),
            AcountSenderId = transaction.AcountSenderId,
            AcountReceiverId = transaction.AcountReceiverId
        };
    }
}