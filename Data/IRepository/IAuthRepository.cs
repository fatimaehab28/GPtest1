using tbackendgp.Models;

namespace tbackendgp.Data.IRepository
{
    public interface IAuthRepository
    {

        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
