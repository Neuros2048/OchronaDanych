using Bankowosc.Server.Entities.Enumerations;
using Bankowosc.Server.Entities;
using Bankowosc.Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Bankowosc.Server.encription;
using Microsoft.EntityFrameworkCore;
using Bankowosc.Shared.Message;

namespace Bankowosc.Server.Services
{
    public class AuthService : IAuthService
    {

        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly int ReHash = 100;
        public AuthService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            return null;
        }

        public async Task<ServiceResponse<string>> Login2()
        {
            var Salt = BCrypt.Net.BCrypt.GenerateSalt();
            string haslo = "Zupelneogronad@n^*(2";

            //haslo = BCrypt.Net.BCrypt.HashPassword(haslo, 16);
            
            haslo = cipher.Encrypt(haslo,
                "$bzMU@*6JzhF$mXWets*+tNupW7#*FNw",
                "NS#aux4fjMxDcUM5");
            var cos = @"-----BEGIN PUBLIC KEY-----
MFswDQYJKoZIhvcNAQEBBQADSgAwRwJAfok54AQfBkuRd3BYANrr1p9wbNrmssjV
isscsRU3ivCm1NxxT1ueF7qgEaVFLBMUXOhvbSq73QGblOS4ISkLEQIDAQAB
-----END PUBLIC KEY-----";
            var ras = RSA.Create();
            ras.ImportFromPem(cos);
            
            Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            return new ServiceResponse<string>
            {
                Success = true,
                Data = haslo,
                Message = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32))//cipher.Decrypt(haslo,"$bzMU@*6JzhF$mXWets*+tNupW7#*FNw",
                //"NS#aux4fjMxDcUM5")
                
            };
            BCrypt.Net.BCrypt.HashPassword("haloludzie");
        }
        
        public async Task<ServiceResponse<string>> Login(string login, string password)
        {
            string message = "Nie poprawne dane logowanie";
            if (await IsBlocked(login))
            {
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = "konto jest zablokowane"
                };
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ClientNumber.Equals(login));
            if (user == null)
            {
                VerifyPasswordHash("a", BCrypt.Net.BCrypt.GenerateSalt() + "a");
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = message
                };
            }
            
            bool ans = VerifyPasswordHash(password, user.PasswordHash);
            if (!ans)
            {
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = message
                };
            }

            await CorrectLogin(login);
            return new ServiceResponse<string>()
            {
                Data = CreateToken(user),
                Success = true
            };

        }

        private bool VerifyPasswordHash(string password, string passwordHash)
        {
            string Salt = passwordHash.Substring(0, 29);
            
            for (int i = 0; i < ReHash; i++)
            {
                password = BCrypt.Net.BCrypt.HashPassword(password, Salt);
            }

            return passwordHash.Equals(password);

        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
             {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.Username),
                 new Claim(ClaimTypes.Role, user.Role.ToString())
             };
            
            var rsa = RSA.Create();
            rsa.ImportFromPem(_config.GetSection("Token").Value.ToCharArray());
            SymmetricSecurityKey key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Token").Value));

            AsymmetricSecurityKey key2 = new RsaSecurityKey(rsa);

            SigningCredentials creds = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

            var token = new JwtSecurityToken(
                               claims: claims,
                               expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
                  );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenHandler;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            

            return new ServiceResponse<int> { Success = true, Data = 2, Message = "Registration successful!" };

        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // using statement to dispose of IDisposable objects
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // generate random salt
                passwordSalt = hmac.Key;
                // generate hash
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        private async Task<bool> IsBlocked(string UserNumber)
        {
            var result = await _context.BlockAccounts.FirstOrDefaultAsync(x => x.UserNumber.Equals(UserNumber));
            if (result == null)
            {
                BlockAccount block = new BlockAccount()
                {
                    LoginAttempts = 1,
                    UserNumber = UserNumber,
                    LastLogin = DateTime.Now
                };
                await _context.BlockAccounts.AddAsync(block);
                await _context.SaveChangesAsync();
                return false;
            }

            if (result.LastLogin.AddMinutes(15) < DateTime.Now)
            {
                result.LoginAttempts = 0;
            }

            result.LoginAttempts++;
            result.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();
            if (result.LoginAttempts > 3)
            {
                return true;
            }

            return false;
        }

        private async Task CorrectLogin(string UserNumber)
        {
            var result = await _context.BlockAccounts.FirstOrDefaultAsync(x => x.UserNumber.Equals(UserNumber));
            result.LoginAttempts = 0;
            await _context.SaveChangesAsync();
        }
        
    }
}
