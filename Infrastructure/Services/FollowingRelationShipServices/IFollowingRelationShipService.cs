using Domain.DTOs.FollowingRelationShipDTOs;

namespace Infrastructure.Services.FollowingRelationShipServices;

public interface IFollowingRelationShipService
{
    Task<Response<GetFollowingRelationShipDto>> GetFollowingRelationShip(string userId);
    Task<Response<bool>> AddFollowingRelationShip(string followingUserId, string userId);
}