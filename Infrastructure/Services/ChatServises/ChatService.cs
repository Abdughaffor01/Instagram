namespace Infrastructure.Services.ChatServises;

public class ChatService:IChatService
{
    private readonly DataContext _cotext;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public ChatService(DataContext cotext,IMapper mapper,UserManager<User> userManager)
    {
        _cotext = cotext;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Response<List<GetChatDto>>> GetChats(string userId)
    {
        var chat = await _cotext.Chats.Where(x=>x.SendUserId==userId||x.ReceiveUserId==userId).ToListAsync();
        
        if (chat.Count == 0) return new Response<List<GetChatDto>>(HttpStatusCode.BadRequest,"Chats not found");
        
        var getChat = _mapper.Map<List<GetChatDto>>(chat);
        
        
        return new Response<List<GetChatDto>>(getChat);

    }

    public async Task<Response<GetChatDto>> AddChat(string sendUserId, AddChatDto model)
    {

        var receiveUser = await _userManager.FindByIdAsync(model.ReceiveUserId);
       
       
        var chat = await _cotext.Chats.FirstOrDefaultAsync(ch=>ch.SendUserId==sendUserId && ch.ReceiveUserId==model.ReceiveUserId);

        if (chat != null)
        {
            var getChatt = new GetChatDto()
            {
                ChatId = chat.ChatId,
                ReceiveUserId = chat.ReceiveUserId,
                SendUserId = sendUserId
            };  

            return new Response<GetChatDto>(getChatt);
                
        }
        
        if (receiveUser == null) return new Response<GetChatDto>(HttpStatusCode.BadRequest,"Error");

        var addChat = new Chat()
        {
            
            SendUserId = sendUserId,
            ReceiveUserId = model.ReceiveUserId 
        };

        await _cotext.Chats.AddAsync(addChat);
        
        await _cotext.SaveChangesAsync();

        var getChat = new GetChatDto()
        {
            ChatId = model.ChatId,
            SendUserId = sendUserId,
            ReceiveUserId = model.ReceiveUserId,

        };

        return new Response<GetChatDto>(getChat);

    }



    public async Task<Response<GetChatDto>> Delete(int id)
    {
        var deleteChat =await _cotext.Chats.FindAsync(id);
        if (deleteChat == null) return new Response<GetChatDto>(HttpStatusCode.BadRequest,"Chat not found");

        _cotext.Chats.Remove(deleteChat);
        
        await _cotext.SaveChangesAsync();

        return new Response<GetChatDto>(HttpStatusCode.OK,"Delete Chat");
    }

    public async Task<Response<GetChatDto>> GetById(int id,string userId)
    {
        var chats =  _cotext.Chats.AsQueryable();
        chats = chats.Where(u => u.SendUserId == userId || u.ReceiveUserId == userId);
        
        
        var getChat = await (from ch in chats 
            select new GetChatDto()
        {
            ChatId = ch.ChatId,
            SendUserId = ch.SendUserId,
            ReceiveUserId = ch.ReceiveUserId,
            Messages = ch.Messages.Select(m => new GetMessageDto()
            {
                  MessageId = m.MessageId,
                  UserId = userId,
                MessageText = m.MessageText,
                SendMessageDate = m.SendMessageDate
            }).ToList()
        }).FirstOrDefaultAsync(ch=>ch.ChatId == id);

        // if(getChat == null) return new Response<GetChatDto>(HttpStatusCode.BadRequest,"Chat Not Found");
        
        
        return new Response<GetChatDto>(getChat); 
    }
}