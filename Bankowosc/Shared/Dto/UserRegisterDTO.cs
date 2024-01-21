using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankowosc.Shared.validator;

namespace Bankowosc.Shared.Dto
{
    public class UserRegisterDTO
    {
        [Required]
        [MaxLength(40, ErrorMessage = "Za długa wartość")]
        public string Username { get; set; }
        [Required,PasswordValidator]
        [MaxLength(40, ErrorMessage = "Za długa wartość")]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage = "Hasła nie są takie same")]
        [MaxLength(40, ErrorMessage = "Za długa wartość")]
        public string ConfirmPassword { get; set; }
        [Required,EmailAddress]
        [MaxLength(40, ErrorMessage = "Za długa wartość")]
        public string Email { get; set; }
        [Required]
        [MinLength(9, ErrorMessage = "Numer telefunu ma mieć długość 9")]
        [MaxLength(9, ErrorMessage = "Numer telefunu ma mieć długość 9")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numer telefonu")]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(11, ErrorMessage = "Pesel ma mieć długość 11")]
        [MaxLength(11, ErrorMessage = "Pesel ma mieć długość 11")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "to nie jest pesel")]
        public string Pesel { get; set; }
        
    }   
}
