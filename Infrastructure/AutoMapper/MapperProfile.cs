using Domain.DTOs.ChatDto;
using Domain.DTOs.PostDTOs;
using Domain.DTOs.ProfileDTOs;
using Domain.Entities.PostEntities;
using Domain.Entities.UserEntities;

namespace Infrastructure.Automapper;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        CreateMap<Post,GetPostDto>();

        CreateMap<UpdateProfileDto, UserProfile>().ReverseMap();
        
        CreateMap<Chat, GetChatDto>();
        
        CreateMap<AddChatDto, Chat>();

        CreateMap<Message, MessageDto>().ReverseMap();

    }
}