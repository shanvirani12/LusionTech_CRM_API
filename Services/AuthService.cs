using LusionTech_CRM_API.Entities;
using LusionTech_CRM_API.Repositories;

namespace LusionTech_CRM_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            return await _userRepository.Authenticate(email, password);
        }

        public async Task<User> Register(User user)
        {
            return await _userRepository.Register(user);
        }
    }
}
