namespace Domain.DTOs.FollowingRelationShipDTOs;

public class SubscribersDto
{
    public int Id { get; set; }
    public GetUserShortInfoDto UserShortInfo { get; set; } = null!;
}