using AutoMapper;
using Domain.DTOs.MessangeDto;
using Infrastructure.Data;

namespace Infrastructure.Services.MessangeServises;

public class MessageServise : IMessageServise
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public MessageServise(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<MessageDtos>>> GetMessenges()
    {
        var messange = await _context.Messanges.ToListAsync();

        if (messange == null) return new Response<List<MessageDtos>>(HttpStatusCode.BadRequest, "Messange not found");

        var getMessange = _mapper.Map<List<MessageDtos>>(messange);

        return new Response<List<MessageDtos>>(getMessange);
    }

    public async Task<Response<MessageDtos>> AddMessange(MessageDtos model)
    {

        var chat = await _context.Chats.FindAsync(model.ChatId);
        var user = await _context.Users.FindAsync(model.UserId);

        if (chat == null || user == null) return new Response<MessageDtos>(HttpStatusCode.BadRequest, "Error");
        var addMessage = _mapper.Map<Message>(model);

        await _context.Messanges.AddAsync(addMessage);
        await _context.SaveChangesAsync();

        return new Response<MessageDtos>(HttpStatusCode.OK, "Message Added");

    }

    public async Task<Response<MessageDtos>> UpdateMessange(MessageDtos model)
    {
        var upMessage = await _context.Messanges.FindAsync(model.MessageId);
        var chat = await _context.Chats.FindAsync(model.ChatId);
        var user = await _context.Users.FindAsync(model.UserId);
        if (upMessage == null||chat==null||user==null) return new Response<MessageDtos>(HttpStatusCode.BadRequest,"Message not found");

        upMessage.UserId = model.UserId;
        upMessage.ChatId = model.ChatId;
        upMessage.MessageText = model.MessageText;
        upMessage.SendMessageDate = model.SendMessageDate;
        
        await _context.SaveChangesAsync();
        return new Response<MessageDtos>(HttpStatusCode.OK,"Message Update");
    }

    public async Task<Response<MessageDtos>> DeleteMessage(int id)
    {
        var deleteMessage = await _context.Messanges.FindAsync(id);
        if (deleteMessage == null) return new Response<MessageDtos>(HttpStatusCode.BadRequest,"Message not found");
        
        _context.Messanges.Remove(deleteMessage);
        await _context.SaveChangesAsync();
        
        return new Response<MessageDtos>(HttpStatusCode.OK,"Messange Delete");
        

    }
}

