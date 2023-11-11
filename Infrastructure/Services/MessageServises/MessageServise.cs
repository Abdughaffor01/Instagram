using AutoMapper;
using Domain.DTOs.MessangeDto;
using Infrastructure.Data;

namespace Infrastructure.Services.MessangeServises;

public class MessageServise : IMessageServise
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public MessageServise(DataContext context, IMapper mapper,UserManager<User> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<Response<MessageDtos>> AddMessange(string userId,MessageDtos model)
    {

        var chat = await _context.Chats.FindAsync(model.ChatId);

        if (chat == null ) return new Response<MessageDtos>(HttpStatusCode.BadRequest, "Error");
        var addMessage = new Message()
        {
        ChatId = model.ChatId,
        UserId =  userId,
        MessageText = model.MessageText,
        SendMessageDate = model.SendMessageDate
        };

        await _context.Messages.AddAsync(addMessage);
        
        await _context.SaveChangesAsync();

        return new Response<MessageDtos>(HttpStatusCode.OK, "Message Added");

    }

  

    public async Task<Response<MessageDtos>> DeleteMessage(int id)
    {
        var deleteMessage = await _context.Messages.FindAsync(id);
        if (deleteMessage == null) return new Response<MessageDtos>(HttpStatusCode.BadRequest,"Message not found");
        
        _context.Messages.Remove(deleteMessage);
        await _context.SaveChangesAsync();
        
        return new Response<MessageDtos>(HttpStatusCode.OK,"Messange Delete");
        

    }
}

