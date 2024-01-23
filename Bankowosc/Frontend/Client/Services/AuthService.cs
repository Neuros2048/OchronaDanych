using System.Net.Http.Json;
using Bankowosc.Shared.Dto;
using Bankowosc.Shared.Message;

namespace Frontend.Client.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;

    }

    public async Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDto)
    {
        var result = await _httpClient.PostAsJsonAsync("api/auth/login/", userLoginDto);

        var data = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

        return data;
    }

    public async Task<ServiceResponse<RegisterRespondDto>> Register(UserRegisterDTO userRegisterDTO)
    {
        var result = await _httpClient.PostAsJsonAsync("api/auth/register/", userRegisterDTO);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<RegisterRespondDto>>();
    }

    public async Task<bool> ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var result = await _httpClient.PutAsJsonAsync("api/auth/change-password/", changePasswordDto);
        if (result.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    
    }
    
}