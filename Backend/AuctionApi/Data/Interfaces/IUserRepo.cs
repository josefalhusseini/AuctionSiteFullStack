using AuctionApi.Data.Entities;

namespace AuctionApi.Data.Interfaces;

public interface IUserRepo
{
    Task<User> RegisterAsync(User user);
    Task<User?> GetByEmailAndPasswordAsync(string email, string password);
}