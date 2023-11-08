using Infrastructure.Services.EmailServices;

namespace Infrastructure.Services.AcountServices;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public AccountService(UserManager<User> userManager,
        IConfiguration configuration,IEmailService emailService)
    {
        _userManager = userManager;
        _configuration = configuration;
        _emailService = emailService;
    }

    public async Task<Response<RegisterDto>> Register(RegisterDto model)
    {
        var mapped = new User()
        {
            UserName = model.Username,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
        
        var response = await _userManager.CreateAsync(mapped, model.Password);
        if (response.Succeeded) return new Response<RegisterDto>(model);
        else return new Response<RegisterDto>(HttpStatusCode.BadRequest, "something is wrong");
    }
    
    public async Task<Response<string>> Login(LoginDto login)
    {
        var user = await _userManager.FindByNameAsync(login.Username);
        if (user != null)
        {
            var checkPassword = await _userManager.CheckPasswordAsync(user, login.Password);
            if (checkPassword)
            {
                var token = await GenerateJwtToken(user);
                return new Response<string>(token);
            }
            else return new Response<string>(HttpStatusCode.BadRequest, "login or password is incorrect");
        }

        return new Response<string>(HttpStatusCode.BadRequest, "login or password is incorrect");
    }

    //Method to generate The Token
    private async Task<string> GenerateJwtToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id),
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );
        
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }

    public async Task<Response<string>> ChangePassword(ChangePasswordDto passwordDto, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        var checkPassword = await _userManager.CheckPasswordAsync(user!, passwordDto.OldPassword);
        if (checkPassword == false) return new Response<string>(HttpStatusCode.BadRequest, "password is incorrect");
        var token = await _userManager.GeneratePasswordResetTokenAsync(user!);
        var result = await _userManager.ResetPasswordAsync(user!, token, passwordDto.Password);
        if (result.Succeeded)return new Response<string>(HttpStatusCode.OK, "success");
        else return new Response<string>(HttpStatusCode.BadRequest, "could not reset your password");
    }

    public async Task<Response<string>> ForgotPasswordTokenGenerator(ForgotPasswordDto forgotPasswordDto)
    {
        var existing = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
        if (existing == null) return new Response<string>(HttpStatusCode.BadRequest, "not found");
        var token = await _userManager.GeneratePasswordResetTokenAsync(existing);
        var url =$"http://localhost:5271/account/resetpassword?token={token}&email={forgotPasswordDto.Email}";
        _emailService.SendEmail(new MessageDto(new []{forgotPasswordDto.Email},"reset password",$"<h1><a href=\"{url}\">reset password</a></h1>"),TextFormat.Html);
        return new Response<string>(HttpStatusCode.OK, "reset password has been sent");
    }

    public async Task<Response<string>> ResetPassword(ResetPasswordDto resetPasswordDto)
    {
        var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
        if (user == null) return new Response<string>(HttpStatusCode.BadRequest, "user not found");
        var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
        if(resetPassResult.Succeeded) return new Response<string>(HttpStatusCode.OK, "success");
        return new Response<string>(HttpStatusCode.BadRequest, "please try again");
    }
}