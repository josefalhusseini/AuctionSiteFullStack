using Microsoft.EntityFrameworkCore;
using AuctionApi.Data.Entities;
using AuctionApi.Data.Interfaces;

namespace AuctionApi.Data.Repos;

public class UserRepo : IUserRepo
{
    private readonly AuctionContext _context;

    public UserRepo(AuctionContext context)
    {
        _context = context;
    }

    public async Task<User> RegisterAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u =>
                u.Email == email &&
                u.Password == password);
    }
}