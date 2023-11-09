using Domain.DTOs.ChatDto;
using Domain.DTOs.PostDTOs;
using Domain.DTOs.ProfileDTOs;

namespace Infrastructure.Automapper;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        CreateMap<Post,GetPostDto>();

        CreateMap<UpdateProfileDto, Profile>().ReverseMap();
        
        CreateMap<Chat, GetChatDto>();
        
        CreateMap<AddChatDto, Chat>();

        CreateMap<Messange, MessageDto>().ReverseMap();

    }
}