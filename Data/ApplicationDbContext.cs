using LusionTech_CRM_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LusionTech_CRM_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        // Add other DbSets as needed
    }
}
