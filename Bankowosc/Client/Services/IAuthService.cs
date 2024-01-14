using Bankowosc.Shared.Dto;
using Bankowosc.Shared.Message;

namespace Bankowosc.Client.Services;

public interface IAuthService
{
    Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDto);

    Task<ServiceResponse<int>> Register(UserRegisterDTO userRegisterDTO);

    Task<ServiceResponse<bool>> ChangePassword(string newPassword);
}