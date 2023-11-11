using Domain.DTOs.ChatDto;

namespace Infrastructure.Services.ChatServises;

public interface IChatService
{
    Task<Response<List<GetChatDto>>> GetChats(string UserId);
    Task<Response<GetChatDto>> AddChat(string sendUserId,AddChatDto model);
    Task<Response<GetChatDto>> Delete(int id);
    Task<Response<GetChatDto>> GetById(int id,string userId);
    
}