using System.Security.AccessControl;

namespace Domain.Entities;

public class Chat
{
    public int ChatId { get; set; }
    public string SendUserId { get; set; }
    public string ReceiveUserId { get; set; }
}