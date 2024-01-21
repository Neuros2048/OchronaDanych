using Bankowosc.Server.encription;
using Bankowosc.Server.Entities.Enumerations;

namespace Bankowosc.Server.Entities.encryptEntities;

public class EncryptUser
{
    private static string k1 = "YUA$XXzp9bsP*He#!qJADY!6@7cdWWZn";
    private static string k2 = "MvP&+sw!Y6whGeX4N@jtYH=k?rW2RWuq";
    private static string k3 = "=!WJaWrP7hN=uSSxWPbjnk+hg$3WnjvJ";
    private static string k4 = "7ZS#5Sj=r%fg%zGSdxsv!nyE3Z!GcFBT";

    public static User Decrept(User user)
    {
        return new User
        {
            Id = user.Id,
            Username = cipher.Decrypt(user.Username, k1, user.Iv),
            PasswordHash = user.PasswordHash,
            Email = cipher.Decrypt(user.Email, k2, user.Iv),
            PhoneNumber = cipher.Decrypt(user.PhoneNumber, k3, user.Iv),
            Role = user.Role,
            ClientNumber = user.ClientNumber,
            Pesel = cipher.Decrypt(user.Pesel, k4, user.Iv),
            Iv = user.Iv,
            DateCreated = user.DateCreated,
        };
    }
    
    public static User Encrypt(User user)
    {
        return new User
        {
            Id = user.Id,
            Username = cipher.Encrypt(user.Username, k1, user.Iv),
            PasswordHash = user.PasswordHash,
            Email = cipher.Encrypt(user.Email, k2, user.Iv),
            PhoneNumber = cipher.Encrypt(user.PhoneNumber, k3, user.Iv),
            Role = user.Role,
            ClientNumber = user.ClientNumber,
            Pesel = cipher.Encrypt(user.Pesel, k4, user.Iv),
            Iv = user.Iv,
            DateCreated = user.DateCreated,
        };
    }

    public static string decryptUsername(string username , byte [] iv)
    {
        return cipher.Decrypt(username, k1, iv);
    } 
}