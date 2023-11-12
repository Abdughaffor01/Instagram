namespace Domain.DTOs.FavoriteDTOs;

public class GetFavoriteDto
{
    public int CountFavorites { get; set; }
    public List<GetPostDto> Posts { get; set; }
}