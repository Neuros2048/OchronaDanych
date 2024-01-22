using System.Security.Cryptography.Xml;
using Bankowosc.Server.encription;

namespace Bankowosc.Server.Entities.encryptEntities;

public class EncryptTransaction
{
    private static string k1 ;
    private static string k2 ;
    private static string k3 ;
    private static string k4 ;
    private static string k5 ;

    public EncryptTransaction()
    {
        
    }

    public static void setKey(string k1, string k2, string k3, string k4, string k5)
    {
        EncryptTransaction.k1 = k1;
        EncryptTransaction.k2 = k2;
        EncryptTransaction.k3 = k3;
        EncryptTransaction.k4 = k4;
        EncryptTransaction.k5 = k5;
    }
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