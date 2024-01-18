using Bankowosc.Server.Entities;
using Bankowosc.Shared.Dto;

namespace Bankowosc.Server.Maper;

public class TransactionMapper
{
    public static PrzelewDto mapTransaction(Transaction transaction)
    {
        return new PrzelewDto
        {
            Nadawca = transaction.Sender,
            KontoNadawcy = transaction.AccountNumberSender,
            Odbiorca = transaction.Receiver,
            KontoOdbiorcy = transaction.AccountNumberReceiver,
            Kwota = transaction.Money,
            DateTime = transaction.DateTime
        };
    }

    public static Transaction mapPrzelewDto(PrzelewDto przelewDto)
    {
        return new Transaction
        {
            Title = przelewDto.Tytul,
            Sender = przelewDto.Nadawca,
            Receiver = przelewDto.Odbiorca,
            AccountNumberSender = przelewDto.KontoNadawcy,
            AccountNumberReceiver = przelewDto.KontoOdbiorcy,
            Money = przelewDto.Kwota,
            DateTime = przelewDto.DateTime
        };
    }

    public static Transaction mapPrzelewDto(MakeTransactionDto transactionDto)
    {
        return new Transaction
        {
            Title = transactionDto.Tytul,
            AccountNumberReceiver = transactionDto.KontoOdbiorcy,
            Money = transactionDto.Kwota
        };
    }
}