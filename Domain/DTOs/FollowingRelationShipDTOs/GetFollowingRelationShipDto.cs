namespace Domain.DTOs.FollowingRelationShipDTOs;

public class GetFollowingRelationShipDto
{
    public List<SubscriptionsDto> Subscriptions { get; set; } = null!;
    public List<SubscribersDto> Subscribers { get; set; } = null!;
}