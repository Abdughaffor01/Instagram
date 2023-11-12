using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Domain.Entities.UserEntities;

namespace Domain.Entities;

public class Chat
{
    [Key] 
    public int ChatId { get; set; }

    public string SendUserId { get; set; }

    public string ReceiveUserId { get; set; }

    public User User { get; set; }

    public List<Message> Messages { get; set; }
}
