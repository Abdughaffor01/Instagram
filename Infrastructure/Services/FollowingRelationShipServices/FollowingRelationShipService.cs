using Domain.DTOs.FollowingRelationShipDTOs;
using Domain.DTOs.UserDTOs;
using Infrastructure.Data;

namespace Infrastructure.Services.FollowingRelationShipServices;

public class FollowingRelationShipService : IFollowingRelationShipService
{
    private readonly DataContext _context;
    public FollowingRelationShipService(DataContext context)=> _context = context;

    public async Task<Response<GetFollowingRelationShipDto>> GetFollowingRelationShip(string userId)
    {
        try
        {
            var followingRelationShips = _context.FollowingRelationShips.AsQueryable();
            var response = await (from f in followingRelationShips
                select new GetFollowingRelationShipDto()
                {
                    Subscribers = (from fr in followingRelationShips
                        where fr.FollowingId == userId
                        select new SubscribersDto()
                        {
                            Id = fr.Id,
                            UserShortInfo = new GetUserShortInfoDto()
                            {
                                UserId = fr.UserId,
                                UserName = fr.User.UserName,
                                Fullname = (fr.User.Profile.FirstName + " " + f.User.Profile.LastName),
                                UserPhoto = fr.User.Profile.Photo
                            }
                        }).ToList(),
                    Subscriptions = (from fr in followingRelationShips
                        where fr.UserId == userId
                        select new SubscriptionsDto()
                        {
                            Id = fr.Id,
                            UserShortInfo = new GetUserShortInfoDto()
                            {
                                UserId = fr.FollowingId,
                                UserName = fr.Following.UserName,
                                Fullname = (fr.Following.Profile.FirstName + " " + f.Following.Profile.LastName),
                                UserPhoto = fr.Following.Profile.Photo
                            }
                        }).ToList()
                }).FirstOrDefaultAsync();
            var totalRecord = followingRelationShips.Count();
            return new Response<GetFollowingRelationShipDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<GetFollowingRelationShipDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    /*public async Task<Response<GetFollowingRelationShipDto>> GetFollowingRelationShipById(int id)
    {
        try
        {
            var following = await _context.FollowingRelationShips.FindAsync(id);
            var mapped = _mapper.Map<GetFollowingRelationShipDto>(following);
            return new Response<GetFollowingRelationShipDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetFollowingRelationShipDto>(HttpStatusCode.BadRequest, e.Message);
        }
    }*/

    public async Task<Response<bool>> AddFollowingRelationShip(string followingUserId, string userId)
    {
        try
        {
            if (followingUserId == userId)
                return new Response<bool>(HttpStatusCode.BadRequest, "You will not be able to subscribe to yourself");
            var user = await _context.Users.FindAsync(userId);
            var followingUser = await _context.Users.FindAsync(followingUserId);
            if (user == null || followingUser == null)
                return new Response<bool>(HttpStatusCode.BadRequest, "User not found");
            
            var findFolowing = await _context.FollowingRelationShips
                .FirstOrDefaultAsync(f=>f.UserId==userId && f.FollowingId==followingUser.Id);
            if (findFolowing != null)
            {
                _context.FollowingRelationShips.Remove(findFolowing);
                return new Response<bool>(false);
            }
            
            var following = new FollowingRelationShip()
            {
                UserId = userId,
                FollowingId = followingUserId,
                DateFollowed = DateTime.UtcNow
            };
            
            await _context.FollowingRelationShips.AddAsync(following);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.BadRequest, ex.Message);
        }
    }
}