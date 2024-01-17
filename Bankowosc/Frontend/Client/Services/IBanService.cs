using Bankowosc.Shared.Dto;

namespace Frontend.Client.Services;

public interface IBanService
{
    Task<List<PrzelewDto>> getTransactions();
}