using Domain.Entities;

namespace Domain.DTOs.ChatDto;

public class GetChatDto
{
    public int ChatId { get; set; }
    
    public string SendUserId { get; set; }
    
    public string ReceiveUserId { get; set; }
    
    public List<Messange> Messanges { get; set; }
}