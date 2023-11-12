namespace Domain.DTOs.AccountDTOs;

public class ChangePasswordDto
{
    public string OldPassword { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}