using LusionTech_CRM_API.Data;
using LusionTech_CRM_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LusionTech_CRM_API.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccount(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccount(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
