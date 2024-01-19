using Bankowosc.Shared.Dto;
using Bankowosc.Shared.Message;

namespace Frontend.Client.Services;

public interface IBanService
{
    Task<List<PrzelewDto>> getTransactions();
    Task<bool> MakeTransaction(MakeTransactionDto transactionDto);
    Task<DaneKontaDto> getAccountData();
    Task<KartaKredytowaDto> getCreditCardData();
    Task<UserDto> UserData();
}