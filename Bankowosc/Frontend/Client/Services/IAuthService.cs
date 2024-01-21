using Bankowosc.Shared.Dto;
using Bankowosc.Shared.Message;

namespace Frontend.Client.Services;

public interface IAuthService
{
    Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDto);

    Task<ServiceResponse<RegisterRespondDto>> Register(UserRegisterDTO userRegisterDTO);

    Task<bool> ChangePassword(ChangePasswordDto changePasswordDto);
}