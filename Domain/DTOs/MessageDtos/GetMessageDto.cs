namespace Domain.DTOs.MessageDTOs;

public class GetMessageDto
{
    public int  MessageId { get; set; }
   
    public string UserId { get; set; } 
    public string MessageText { get; set; }
    
    public DateTime SendMessageDate { get; set; }
}