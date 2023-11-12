namespace Domain.DTOs.FollowingRelationShipDTOs;

public class SubscriptionsDto
{
    public int Id { get; set; }
    public GetUserShortInfoDto UserShortInfo { get; set; } = null!;
}