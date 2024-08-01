using LusionTech_CRM_API.Entities;

namespace LusionTech_CRM_API.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(Guid id);
        Task<Account> AddAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task DeleteAccount(Guid id);
    }
}
