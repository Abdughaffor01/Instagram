namespace Infrastructure.Services.EmailServices;

public interface IEmailService
{
    void SendEmail(MessageDto model,TextFormat format);
}