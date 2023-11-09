using Domain.DTOs.MessangeDto;
using Domain.Entities;

namespace Domain.DTOs.ChatDto;

public class GetChatDto
{
    public int ChatId { get; set; }
    
    public string SendUserId { get; set; }
    
    public string ReceiveUserId { get; set; }
    
    public List<GetMessageDto> Messages { get; set; }
    
}