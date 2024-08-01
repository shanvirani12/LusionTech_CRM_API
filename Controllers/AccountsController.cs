using LusionTech_CRM_API.Data;
using LusionTech_CRM_API.DTOs;
using LusionTech_CRM_API.Entities;
using LusionTech_CRM_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LusionTech_CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _repository;

        public AccountsController(IAccountRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccounts()
        {
            var accounts = await _repository.GetAccounts();
            var accountDTOs = accounts.Select(account => new AccountDTO
            {
                Id = account.Id,
                Name = account.Name,
                Email = account.Email,
            }).ToList();

            return accountDTOs;
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccount(Guid id)
        {
            var account = await _repository.GetAccount(id);
            if (account == null)
            {
                return NotFound();
            }

            var accountDTO = new AccountDTO
            {
                Id = account.Id,
                Name = account.Name,
                Email = account.Email,
            };

            return accountDTO;
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(Guid id, AccountDTO accountDTO)
        {
            if (id != accountDTO.Id)
            {
                return BadRequest();
            }

            var account = new Account
            {
                Id = accountDTO.Id,
                Name = accountDTO.Name,
                Email = accountDTO.Email,
            };

            try
            {
                await _repository.UpdateAccount(account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<ActionResult<AccountDTO>> PostAccount(AccountDTO accountDTO)
        {
            var account = new Account
            {
                Name = accountDTO.Name,
                Email = accountDTO.Email,
            };

            account = await _repository.AddAccount(account);

            accountDTO.Id = account.Id;

            return CreatedAtAction(nameof(GetAccount), new { id = accountDTO.Id }, accountDTO);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var account = await _repository.GetAccount(id);
            if (account == null)
            {
                return NotFound();
            }

            await _repository.DeleteAccount(id);

            return NoContent();
        }

        private async Task<bool> AccountExists(Guid id)
        {
            var account = await _repository.GetAccount(id);
            return account != null;
        }
    }
}
