using Domain.DTOs.ChatDto;
using Domain.DTOs.PostDTOs;

namespace Infrastructure.Automapper;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        CreateMap<Post,GetPostDto>();
        
        CreateMap<Chat, GetChatDto>();
        CreateMap<AddChatDto, Chat>();

        CreateMap<Messange, MessageDto>().ReverseMap();
    }
}