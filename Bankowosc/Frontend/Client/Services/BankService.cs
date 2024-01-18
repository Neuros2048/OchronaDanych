using System.Net.Http.Json;
using Bankowosc.Shared.Dto;
using Bankowosc.Shared.Message;

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
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<PrzelewDto>>>("api/Bank/history");
        if (result.Success)
        {
            return result.Data;
        }

        return new List<PrzelewDto>();
    }

    public async Task<bool> MakeTransaction(MakeTransactionDto transactionDto)
    {
        var respond = await _http.PostAsJsonAsync("api/Bank/transaction", transactionDto);
        if (respond.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }
    
    public async Task<DaneKontaDto> getAccountData()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<DaneKontaDto>>("api/Bank/AccountInfo");
        if (result.Success)
        {
            return result.Data;
        }

        return new DaneKontaDto();
    }
}