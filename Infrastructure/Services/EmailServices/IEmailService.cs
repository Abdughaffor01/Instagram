namespace Infrastructure.Services.EmailServices;

public interface IEmailService
{
    void SendEmail(MessageEmailDto model,TextFormat format);
}