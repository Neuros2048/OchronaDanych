using System.Transactions;
using Bankowosc.Server.Maper;
using Bankowosc.Server.Models;
using Bankowosc.Shared.Dto;
using Bankowosc.Shared.Message;
using Microsoft.EntityFrameworkCore;
using Transaction = Bankowosc.Server.Entities.Transaction;

namespace Bankowosc.Server.Services;

public class BankService
{
    private DataContext _context;
    public BankService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<bool>> MakeTransaction(PrzelewDto transaction, long userId)
    {
        var accout = await _context.Acounts.FirstOrDefaultAsync(x => x.AccountNumber == transaction.KontoNadawcy);
        if (accout == null)
        {
            return new ServiceResponse<bool>()
            {
                Success = false,
                Message = "Konto nadawcy nie istnieje",
            };
        }

        if (accout.UserId != userId)
        {
            return new ServiceResponse<bool>()
            {
                Success = false,
                Message = "To nie jest twoje konto",
            };
        }

        if (accout.Money < transaction.Kwota)
        {
            return new ServiceResponse<bool>()
            {
                Success = false,
                Message = "Nie masz wystarczająco pieniędzy",
            };
        }

        var recAccout = await _context.Acounts.FirstOrDefaultAsync(x => x.AccountNumber == transaction.KontoOdbiorcy);
        if (recAccout == null)
        {
            return new ServiceResponse<bool>()
            {
                Success = false,
                Message = "Konto odbiorcy nie istnieje",
            };
        }

        accout.Money -= transaction.Kwota;
        recAccout.Money += transaction.Kwota;
        Transaction newTransaction = TransactionMapper.mapPrzelewDto(transaction);
        newTransaction.AcountSenderId = accout.Id;
        newTransaction.AcountReceiverId = recAccout.Id;
        await _context.TransacionHistory.AddAsync(newTransaction);
        await _context.SaveChangesAsync();
        return new ServiceResponse<bool>()
        {
            Success = true,
            Message = "Przele został wykonany",
        };
    }

    public async Task<ServiceResponse<List<PrzelewDto>>> UserTransaction(long userId)
    {
        var account = await _context.Acounts.FirstOrDefaultAsync(x => x.UserId == userId);
        if (account == null)
        {
            return new ServiceResponse<List<PrzelewDto>>()
            {
                Success = false,
                Message = "Konto odbiorcy nie istnieje",
            };
        }

        var ans = _context.TransacionHistory.Where(x =>
                x.AcountReceiverId == account.Id || x.AcountSenderId == account.Id)
            .Select(x => TransactionMapper.mapTransaction(x)).ToList();
        return new ServiceResponse<List<PrzelewDto>>()
        {
            Success = true,
            Data = ans,
        };
    }
}