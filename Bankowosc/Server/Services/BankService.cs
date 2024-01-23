using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Bankowosc.Server.encription;
using Bankowosc.Server.Entities.encryptEntities;
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

        if (transaction.Kwota == 0M)
        {
            return new ServiceResponse<bool>()
            {
                Success = false,
                Message = "Kwota musi być większ niż 0",
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

        if (accout.Id == recAccout.Id)
        {
            return new ServiceResponse<bool>()
            {
                Success = false,
                Message = "Nie możesz wysałać przelewów do siebie",
            }; 
        }
        if (recAccout.Money + transaction.Kwota > 228162514264337593543950335M)
        {
            return new ServiceResponse<bool>()
            {
                Success = false,
                Message = "Za duża kwota Przesłania",
            };
        }

        accout.Money -= transaction.Kwota;
        recAccout.Money += transaction.Kwota;
        Transaction newTransaction = TransactionMapper.mapPrzelewDto(transaction);
        newTransaction.AccountNumberSender = accout.AccountNumber;
        newTransaction.AcountSenderId = accout.Id;
        newTransaction.AcountReceiverId = recAccout.Id;
        newTransaction.Sender = EncryptUser.decryptUsername(user.Username,user.Iv) ;
        var revecerName = await _context.Users.FirstOrDefaultAsync(x => x.Id == recAccout.UserId);
        newTransaction.Receiver = EncryptUser.decryptUsername(revecerName.Username,revecerName.Iv);
        newTransaction.DateTime = DateTime.Now;
        newTransaction.Iv = cipher.GetRandomBytes(16);
        newTransaction = EncryptTransaction.EcryptTransaction(newTransaction);
      
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
            .Select(x => TransactionMapper.mapTransaction(EncryptTransaction.DecryptTransaction(x))).ToList();
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
    
    public async Task<ServiceResponse<KartaKredytowaDto>> CreditCardInfo(long userId)
    {
        var result = await _context.Acounts.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result == null)
        {
            return new ServiceResponse<KartaKredytowaDto>()
            {
                Success = false,
                Message = "Użytkownik nie ma konta"
            };
        }

        var card = await _context.CreditCredits.FirstOrDefaultAsync(x => x.AcountId == result.Id);
        if (card == null)
        {
            return new ServiceResponse<KartaKredytowaDto>()
            {
                Success = false,
                Message = "Użytkownik nie ma karty"
            };
        }

        return new ServiceResponse<KartaKredytowaDto>()
        {
            Success = true,
            Data = CreditCardMapper.CredicCardToDto(EncryptCreditCard.Dencrypt(card))
        };
    }
    
    public async Task<ServiceResponse<UserDto>> UserInfo(long userId)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (result == null)
        {
            return new ServiceResponse<UserDto>()
            {
                Success = false,
                Message = "Wystąpił błąd"
            };
        }

        return new ServiceResponse<UserDto>()
        {
            Data = UserMapper.UsertoDot(EncryptUser.Decrept(result)),
            Success = true
        };
    }
    
}