namespace Domain.Entities;

public class Message
{
    public int  MessageId { get; set; }
   
    public int ChatId { get; set; }
    
    public string UserId { get; set; }
    
    public string MessageText { get; set; }
    
    public DateTime SendMessageDate { get; set; }
  
    public Chat Chat { get; set; }
    
    public User ApplicationUser { get; set; }
}