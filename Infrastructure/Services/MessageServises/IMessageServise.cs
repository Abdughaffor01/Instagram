using Domain.DTOs.MessangeDto;

namespace Infrastructure.Services.MessangeServises;

public interface IMessageServise
{
   Task< Response<MessageDtos>> AddMessange(string serId,MessageDtos model);
   Task<Response<MessageDtos>> DeleteMessage(int id);
}
