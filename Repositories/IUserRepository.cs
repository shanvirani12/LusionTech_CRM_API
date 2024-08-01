using LusionTech_CRM_API.Entities;

namespace LusionTech_CRM_API.Repositories
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string email, string password);
        Task<User> Register(User user);
        Task<bool> UserExists(string email);
    }
}
