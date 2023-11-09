using Domain.Enums;
using Infrastructure.Data;

namespace Infrastructure.Seed;

public class Seeder
{
    private readonly DataContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    public Seeder(UserManager<ApplicationUser> userManager, DataContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<bool> SeedUser()
    {
        var existing = await _userManager.FindByNameAsync("SuperAdmin");
        if (existing != null) return false;

        var identity = new ApplicationUser()
        {
            UserName = "SuperAdmin",
            PhoneNumber = "+992987849660",
            Email = "SuperAdmin@gmail.com",
        };

        var result = await _userManager.CreateAsync(identity, "$uperAdnn1n");
        return result.Succeeded;
    }
}