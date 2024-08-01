using LusionTech_CRM_API.Entities;

namespace LusionTech_CRM_API.Services
{
    public interface IAuthService
    {
        Task<User> Authenticate(string email, string password);
        Task<User> Register(User user);
    }
}
