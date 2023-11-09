using AutoMapper;
using Domain.DTOs.ChatDto;
using Infrastructure.Data;

namespace Infrastructure.Services.ChatServises;

public class ChatServise:IChatServise
{
    private readonly DataContext _cotext;
    private readonly IMapper _mapper;

    public ChatServise(DataContext cotext,IMapper mapper)
    {
        _cotext = cotext;
        _mapper = mapper;
    }

    public async Task<Response<List<GetChatDto>>> GetChats()
    {
        var chat = await _cotext.Chats.ToListAsync();
       
        if (chat == null) return new Response<List<GetChatDto>>(HttpStatusCode.BadRequest, "Chat not found");

        var getChat = _mapper.Map<List<GetChatDto>>(chat);
        
        return new Response<List<GetChatDto>>(getChat);

    }

    public async Task<Response<GetChatDto>> AddChat(AddChatDto model)
    {
        var sendUser = await _cotext.Users.FindAsync(model.SendUserId);
        
        var receiveUser= await _cotext.Users.FindAsync(model.ReceiveUserId);
        
        if (sendUser == null || receiveUser == null) return new Response<GetChatDto>(HttpStatusCode.BadRequest,"Error");

        var addChat = _mapper.Map<Chat>(model);
        
        _cotext.Chats.AddAsync(addChat);
        
        await _cotext.SaveChangesAsync();

        return new Response<GetChatDto>(HttpStatusCode.OK,"Chat Added");

    }

    public async Task<Response<GetChatDto>> UpdateChat(AddChatDto model)
    {
        var chat = await _cotext.Chats.FindAsync(model.ChatId);
        
        if (chat == null) return new Response<GetChatDto>(HttpStatusCode.BadRequest,"Chat not found");

        chat.SendUserId = model.SendUserId;
        chat.ReceiveUserId = model.ReceiveUserId;

       await _cotext.SaveChangesAsync();

       return new Response<GetChatDto>(HttpStatusCode.OK, "Chat Update Successfully");
    }

    public async Task<Response<GetChatDto>> Delete(int id)
    {
        var deleteChat =await _cotext.Chats.FindAsync(id);
        if (deleteChat == null) return new Response<GetChatDto>(HttpStatusCode.BadRequest,"Chat not found");

        _cotext.Chats.Remove(deleteChat);
        
        await _cotext.SaveChangesAsync();

        return new Response<GetChatDto>(HttpStatusCode.OK,"Delete Chat");
    }
}