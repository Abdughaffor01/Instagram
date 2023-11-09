using Domain.Entities;

namespace Domain.DTOs.ChatDto;

public class AddChatDto
{
    public int ChatId { get; set; }
    public string ReceiveUserId { get; set; }
    
}