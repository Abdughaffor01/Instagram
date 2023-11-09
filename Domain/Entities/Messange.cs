namespace Domain.Entities;

public class Messange
{
    public int  MessangeId { get; set; }
   
    public int ChatId { get; set; }
    
    public string UserId { get; set; }
    
    public string MessangeText { get; set; }
    
    public DateTime SendMessangeDate { get; set; }
  
    public Chat Chat { get; set; }
    
    public User User { get; set; }
}