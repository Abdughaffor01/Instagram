namespace Domain.DTOs.AccountDTOs;

public class RegisterDto
{
    public string Username { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}