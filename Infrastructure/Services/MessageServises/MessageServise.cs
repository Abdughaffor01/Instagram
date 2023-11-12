namespace Infrastructure.Services.MessageServises;

public class MessageServise : IMessageServise
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public MessageServise(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<MessageDto>>> GetMessenges()
    {
        var messange = await _context.Messanges.ToListAsync();

        if (messange == null) return new Response<List<MessageDto>>(HttpStatusCode.BadRequest, "Messange not found");

        var getMessange = _mapper.Map<List<MessageDto>>(messange);

        return new Response<List<MessageDto>>(getMessange);
    }

    public async Task<Response<MessageDto>> AddMessange(MessageDto model)
    {

        var chat = await _context.Chats.FindAsync(model.ChatId);
        var user = await _context.Users.FindAsync(model.UserId);

        if (chat == null || user == null) return new Response<MessageDto>(HttpStatusCode.BadRequest, "Error");
        var addMessage = _mapper.Map<Message>(model);

        await _context.Messanges.AddAsync(addMessage);
        await _context.SaveChangesAsync();

        return new Response<MessageDto>(HttpStatusCode.OK, "Message Added");

    }

    public async Task<Response<MessageDto>> UpdateMessange(MessageDto model)
    {
        var upMessage = await _context.Messanges.FindAsync(model.MessageId);
        var chat = await _context.Chats.FindAsync(model.ChatId);
        var user = await _context.Users.FindAsync(model.UserId);
        if (upMessage == null||chat==null||user==null) return new Response<MessageDto>(HttpStatusCode.BadRequest,"Message not found");

        upMessage.UserId = model.UserId;
        upMessage.ChatId = model.ChatId;
        upMessage.MessageText = model.MessageText;
        upMessage.SendMessageDate = model.SendMessageDate;
        
        await _context.SaveChangesAsync();
        return new Response<MessageDto>(HttpStatusCode.OK,"Message Update");
    }

    public async Task<Response<MessageDto>> DeleteMessage(int id)
    {
        var deleteMessage = await _context.Messanges.FindAsync(id);
        if (deleteMessage == null) return new Response<MessageDto>(HttpStatusCode.BadRequest,"Message not found");
        
        _context.Messanges.Remove(deleteMessage);
        await _context.SaveChangesAsync();
        
        return new Response<MessageDto>(HttpStatusCode.OK,"Messange Delete");
        

    }
}

