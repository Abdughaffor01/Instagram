namespace Domain.DTOs.MessangeDto;

public class MessageDtos
{
    public int  MessageId { get; set; }
   
    public int ChatId { get; set; }
    
    public string UserId { get; set; }
    
    public string MessageText { get; set; }
    
    public DateTime SendMessageDate { get; set; }

}