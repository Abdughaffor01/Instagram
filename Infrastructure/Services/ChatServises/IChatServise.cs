using Domain.DTOs.ChatDto;

namespace Infrastructure.Services.ChatServises;

public interface IChatServise
{
    Task<Response<List<GetChatDto>>> GetChats();
    Task<Response<GetChatDto>> AddChat(AddChatDto model);
    Task<Response<GetChatDto>> UpdateChat(AddChatDto model);
    Task<Response<GetChatDto>> Delete(int id);
}