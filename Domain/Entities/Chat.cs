namespace Domain.Entities;

public class Chat
{
    [Key] 
    public int ChatId { get; set; }

    public string SendUserId { get; set; }
    
    public User SendUser { get; set; }
    public string ReceiveUserId { get; set; }

    public User ReceiveUser { get; set; }

    public List<Message> Messages { get; set; }
}