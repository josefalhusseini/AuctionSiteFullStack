using AuctionApi.Data.Entities;

namespace AuctionApi.Core.Interfaces;

public interface IUserService
{
    Task<User> RegisterAsync(User user);
    Task<int?> LoginAsync(string name, string password);
}