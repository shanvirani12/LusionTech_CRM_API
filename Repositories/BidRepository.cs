using LusionTech_CRM_API.Data;
using LusionTech_CRM_API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LusionTech_CRM_API.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ApplicationDbContext _context;

        public BidRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bid>> GetAllBids()
        {
            return await _context.Bids.Include(b => b.Account).Include(b => b.User).ToListAsync();
        }

        public async Task<Bid> GetBidById(int id)
        {
            return await _context.Bids.Include(b => b.Account).Include(b => b.User).FirstOrDefaultAsync(b => b.BidId == id);
        }

        public async Task<Bid> AddBid(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
            return bid;
        }

        public async Task<Bid> UpdateBid(Bid bid)
        {
            _context.Bids.Update(bid);
            await _context.SaveChangesAsync();
            return bid;
        }

        public async Task<bool> DeleteBid(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            if (bid == null) return false;

            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
