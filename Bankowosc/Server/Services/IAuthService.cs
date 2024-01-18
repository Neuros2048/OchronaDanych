using Bankowosc.Server.Entities;
using Bankowosc.Shared.Message;

namespace Bankowosc.Server.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(string email, string password);

        Task<ServiceResponse<int>> Register(User user, string password);

        Task<bool> UserExists(string email);

        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);

        Task<ServiceResponse<string>> Login2();
    }
}
