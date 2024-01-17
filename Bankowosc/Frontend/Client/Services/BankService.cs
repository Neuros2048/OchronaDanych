using Bankowosc.Shared.Dto;

namespace Frontend.Client.Services;

public class BankService : IBanService
{
    private readonly HttpClient _http;
    public BankService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    public async Task<List<PrzelewDto>> getTransactions()
    {
        throw new NotImplementedException();
    }
}