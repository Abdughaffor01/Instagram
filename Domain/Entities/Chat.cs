using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Domain.Entities;

public class Chat
{
    [Key] 
    public int ChatId { get; set; }

    public string SendUserId { get; set; }
    
    public ApplicationUser SendUser { get; set; }
    public string ReceiveUserId { get; set; }
    
    public ApplicationUser ReceiveUser { get; set; }
    public List<Message> Messages { get; set; }
}