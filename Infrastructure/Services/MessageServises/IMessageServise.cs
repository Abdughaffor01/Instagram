namespace Infrastructure.Services.MessageServises;

public interface IMessageServise
{
   Task<Response<List<MessageDto>>> GetMessenges();
    
   Task< Response<MessageDto>> AddMessange(MessageDto model);
    
   Task<Response<MessageDto>> UpdateMessange(MessageDto model);

   Task<Response<MessageDto>> DeleteMessage(int id);
}
