using LusionTech_CRM_API.Data;
using LusionTech_CRM_API.Entities;
using Microsoft.EntityFrameworkCore;


namespace LusionTech_CRM_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }

        public async Task<User> Register(User user)
        {
            if (await UserExists(user.Email))
            {
                return null;
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
