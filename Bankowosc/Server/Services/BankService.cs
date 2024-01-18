using System.ComponentModel.DataAnnotations;
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

    public async Task<ServiceResponse<bool>> MakeTransaction(MakeTransactionDto transaction, long userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        
        if (user == null)
        {
            return new ServiceResponse<bool>()
            {
                Success = false,
                Message = "Konto nadawcy nie istnieje",
            };
        }
        var accout = await _context.Acounts.FirstOrDefaultAsync(x => x.UserId == userId);

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
        newTransaction.AccountNumberSender = accout.AccountNumber;
        newTransaction.AcountSenderId = accout.Id;
        newTransaction.AcountReceiverId = recAccout.Id;
        newTransaction.Sender = user.Username;
        var revecerName = await _context.Users.FirstOrDefaultAsync(x => x.Id == recAccout.UserId);
        newTransaction.Receiver = revecerName.Username;
        newTransaction.DateTime = DateTime.Now;
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
        ans.Reverse();
        return new ServiceResponse<List<PrzelewDto>>()
        {
            Success = true,
            Data = ans,
        };
    }

    public async Task<ServiceResponse<DaneKontaDto>> UserAccountInfo(long userId)
    {
        var result = await _context.Acounts.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result == null)
        {
            return new ServiceResponse<DaneKontaDto>()
            {
                Success = false,
                Message = "Użytkownik nie ma konta"
            };
        }

        return new ServiceResponse<DaneKontaDto>()
        {
            Data = new DaneKontaDto()
            {
                Money = result.Money,
                AccountNumber = result.AccountNumber
            },
            Success = true
        };
    }
    
}