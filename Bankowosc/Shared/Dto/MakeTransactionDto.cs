using System.ComponentModel.DataAnnotations;

namespace Bankowosc.Shared.Dto;

public class MakeTransactionDto
{
    
    [Required]
    [MinLength(1,ErrorMessage = "Pole jest wymagane")]
    public string Tytul { get; set; } = "";
    [Required]
    [MinLength(26, ErrorMessage = "Za krótkie")]
    [MaxLength(26, ErrorMessage = "Za długie")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "to nie jest numer konta")]
    public string KontoOdbiorcy { get; set; } 
    [Required]
    [RegularExpression(@"^[0-9]{1,15}.?[0-9]{0,2}$", ErrorMessage = "to nie jest poprawna kwota")]
    public decimal Kwota { get; set; }
}