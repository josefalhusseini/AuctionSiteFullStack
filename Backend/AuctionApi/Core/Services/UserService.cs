using AuctionApi.Core.Interfaces;
using AuctionApi.Data.Entities;
using AuctionApi.Data.Interfaces;

namespace AuctionApi.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _repo;

    public UserService(IUserRepo repo)
    {
        _repo = repo;
    }

    public async Task<User> RegisterAsync(User user)
    {
        return await _repo.RegisterAsync(user);
    }

    public async Task<int?> LoginAsync(string email, string password)
    {
        var user = await _repo.GetByEmailAndPasswordAsync(email, password);
        return user?.Id;
    }
}