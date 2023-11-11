using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Domain.Entities;

public class Chat
{
    [Key] 
    public int ChatId { get; set; }

    public string SendUserId { get; set; }

    public string ReceiveUserId { get; set; }

    public User User { get; set; }

    public List<Messange> Messanges { get; set; }
}