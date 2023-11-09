using Domain.DTOs.MessangeDto;

namespace Infrastructure.Services.MessangeServises;

public interface IMessageServise
{
   Task<Response<List<MessageDtos>>> GetMessenges();
    
   Task< Response<MessageDtos>> AddMessange(MessageDtos model);
    
   Task<Response<MessageDtos>> UpdateMessange(MessageDtos model);

   Task<Response<MessageDtos>> DeleteMessage(int id);
}
