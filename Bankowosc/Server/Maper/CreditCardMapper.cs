using Bankowosc.Server.Entities;
using Bankowosc.Shared.Dto;

namespace Bankowosc.Server.Maper;

public class CreditCardMapper
{
    public static KartaKredytowaDto CredicCardToDto(CreditCard creditCard)
    {
        return new KartaKredytowaDto
        {
            Numbers = creditCard.Numbers,
            SpecialNumber = creditCard.SpecialNumber,
            Name = creditCard.Name,
            EndDate = creditCard.EndDate,
        };
    }
}