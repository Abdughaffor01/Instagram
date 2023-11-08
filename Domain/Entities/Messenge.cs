using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace Domain.Entities;

public class Messenge
{
    public int  MessengeId { get; set; }
    public string ChatId { get; set; }
    public string UserId { get; set; }
    
}