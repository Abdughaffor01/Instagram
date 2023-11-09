namespace Domain.DTOs.MessangeDto;

public class MessageDtos
{
    public int  MessangeId { get; set; }
   
    public int ChatId { get; set; }
    
    public string UserId { get; set; }
    
    public string MessangeText { get; set; }
    
    public DateTime SendMessangeDate { get; set; }

}