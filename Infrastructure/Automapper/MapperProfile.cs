using Domain.DTOs.PostDTOs;

namespace Infrastructure.Automapper;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        CreateMap<Post,GetPostDto>();
    }
}