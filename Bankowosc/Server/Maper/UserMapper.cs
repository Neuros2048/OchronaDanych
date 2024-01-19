using Bankowosc.Server.Entities;
using Bankowosc.Shared.Dto;

namespace Bankowosc.Server.Maper;

public class UserMapper
{
    public static UserDto UsertoDot(User user)
    {
        return new UserDto
        {
            Email = user.Email,
            Phone = user.PhoneNumber,
            Name = user.Username
        };
    }
}