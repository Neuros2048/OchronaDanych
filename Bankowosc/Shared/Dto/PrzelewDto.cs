using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankowosc.Shared.Dto
{
    public class PrzelewDto
    {

        public string Nadawca { get; set; }
        public int KontoNadawcy { get; set; }
        public string Odbiorca { get; set; }
        [Required]
        [MinLength(26, ErrorMessage = "Za krótkie")]
        [MaxLength(26, ErrorMessage = "Za długie")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "to nie jest numer konta")]
        public string KontoOdbiorcy { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+.?[0-9]{0,2}$", ErrorMessage = "to nie jest poprawna kwota")]
        public double Kwota { get; set; }
        public DateTime DateTime { get; set; }

    }
}
