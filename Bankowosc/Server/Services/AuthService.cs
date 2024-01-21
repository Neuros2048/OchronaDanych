using Bankowosc.Server.Entities.Enumerations;
using Bankowosc.Server.Entities;
using Bankowosc.Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Bankowosc.Server.encription;
using Bankowosc.Server.Entities.encryptEntities;
using Bankowosc.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using Bankowosc.Shared.Message;

namespace Bankowosc.Server.Services
{
    public class AuthService : IAuthService
    {

        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly int workFacktor = 16;
        public AuthService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(ChangePasswordDto changePasswordDto, int userId)
        {
            if (!changePasswordDto.NewPassword.Equals(changePasswordDto.ConfirmPassword))
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Message = "Nowe hasła nie są idetyczne"
                };
            }
            string message = "Nie stare hasło";
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (await IsBlocked(user.ClientNumber))
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Message = "Zmiana hasła jest zablokowana"
                };
            }
            
            
            
            bool ans = VerifyPasswordHash(changePasswordDto.LastPassword, user.PasswordHash);
            if (!ans)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Message = message
                };
            }

            await CorrectLogin(user.ClientNumber);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword, workFacktor);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>()
            {
                Message = "hasło zostało zmienione",
                Success = true
            };
        }

        public async Task<ServiceResponse<string>> Login2()
        {
            
            var b = cipher.GetRandomBytes(16);
            string haslo = "Bolakne12#$0sa";
            
            haslo = BCrypt.Net.BCrypt.HashPassword(haslo, 16);
         
        
          
            
            return new ServiceResponse<string>
            {
                Success = true,
                Data = "CTF",
                Message =  "znalazłeś flage"
                
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
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);

            

        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
             {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.Username),
                 new Claim(ClaimTypes.Role, user.Role.ToString())
             };


            SymmetricSecurityKey key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                               claims: claims,
                               expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
                  );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenHandler;
        }

        public async Task<ServiceResponse<RegisterRespondDto>> Register(UserRegisterDTO userRegisterDto)
        {
            User user = new User();
            Account account = new Account();
            string userlogin = randomnumbers(10);
            int error = 0;
            while (await _context.Users.FirstOrDefaultAsync(x => x.ClientNumber.Equals(userlogin)) != null)
            {
                userlogin = randomnumbers(10);
                error++;
                if (error == 100)
                {
                    break;
                }
            }

            if (error == 100)
            {
                return new ServiceResponse<RegisterRespondDto>()
                {
                    Success = false
                };
            }

            string accountNumbers = randomnumbers(26);
            error = 0;
            while (await _context.Acounts.FirstOrDefaultAsync(x=>x.AccountNumber.Equals(accountNumbers))!= null)
            {
                accountNumbers = randomnumbers(26);
                error++;
                if (error == 100)
                {
                    break;
                }
            }
            if (error == 100)
            {
                return new ServiceResponse<RegisterRespondDto>()
                {
                    Success = false
                };
            }

            user.ClientNumber = userlogin;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password, workFacktor);
            user.Iv = cipher.GetRandomBytes(16);
            user.Role = Role.USER;
            user.Username = userRegisterDto.Username;
            user.Email = userRegisterDto.Email;
            user.Pesel = userRegisterDto.Pesel;
            user.PhoneNumber = userRegisterDto.PhoneNumber;
            user = EncryptUser.Encrypt(user);
            var res = await _context.Users.AddAsync(user);
            user = res.Entity;
            account.Money = 0;
            account.AccountNumber = accountNumbers;
            account.User = user;
            await _context.Acounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return new ServiceResponse<RegisterRespondDto>()
            {
                Data = new RegisterRespondDto()
                {
                    accountNumber = account.AccountNumber,
                    login = user.ClientNumber
                },
                Success = true
            };
            
        }

        private string randomnumbers(int size)
        {
            Random rnd = new Random();
            string ans = string.Empty;
            for (int i = 0; i < size; i++)
            {
                ans += rnd.Next(10).ToString();
            }

            return ans;
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
