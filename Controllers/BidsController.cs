using LusionTech_CRM_API.DTOs;
using LusionTech_CRM_API.Entities;
using LusionTech_CRM_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LusionTech_CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class BidsController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;

        public BidsController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBids()
        {
            var bids = await _bidRepository.GetAllBids();
            return Ok(bids);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBidById(int id)
        {
            var bid = await _bidRepository.GetBidById(id);
            if (bid == null)
            {
                return NotFound();
            }
            return Ok(bid);
        }

        [HttpPost]
        public async Task<IActionResult> AddBid(BidDTO bidDTO)
        {
            var bid = new Bid
            {
                Link = bidDTO.Link,
                AccountID = bidDTO.AccountID,
                UserID = bidDTO.UserID,
                DateTime = bidDTO.DateTime
            };

            var newBid = await _bidRepository.AddBid(bid);
            return CreatedAtAction(nameof(GetBidById), new { id = newBid.BidId }, newBid);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBid(int id, BidDTO bidDTO)
        {
            var bid = await _bidRepository.GetBidById(id);
            if (bid == null)
            {
                return NotFound();
            }

            bid.Link = bidDTO.Link;
            bid.AccountID = bidDTO.AccountID;
            bid.UserID = bidDTO.UserID;
            bid.DateTime = bidDTO.DateTime;

            await _bidRepository.UpdateBid(bid);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBid(int id)
        {
            var result = await _bidRepository.DeleteBid(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
