using LusionTech_CRM_API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LusionTech_CRM_API.Repositories
{
    public interface IBidRepository
    {
        Task<IEnumerable<Bid>> GetAllBids();
        Task<Bid> GetBidById(int id);
        Task<Bid> AddBid(Bid bid);
        Task<Bid> UpdateBid(Bid bid);
        Task<bool> DeleteBid(int id);
    }
}
