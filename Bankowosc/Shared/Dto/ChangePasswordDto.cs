namespace Bankowosc.Shared.Dto;

public class ChangePasswordDto
{
    public string LastPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}