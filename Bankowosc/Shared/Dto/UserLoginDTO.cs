using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankowosc.Shared.validator;

namespace Bankowosc.Shared.Dto
{
    public class UserLoginDTO
    {
        [Required]
        [MinLength(10, ErrorMessage = "Login musi mięć długość 10")]
        [MaxLength(10, ErrorMessage = "Login musi mięć długość 10")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Tylko cyfry występują w loginie")]
        public string Login { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Za długa wartość")]
        public string Password { get; set; }
    }
}
