using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using tbackendgp.Data.IRepository;
using tbackendgp.Models;

namespace tbackendgp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyOfferController : ControllerBase
    {
        private readonly IPropertyOfferRepository _propertyOfferRepository;

        public PropertyOfferController(IPropertyOfferRepository propertyOfferRepository)
        {
            _propertyOfferRepository = propertyOfferRepository;
        }

        // 🟢 Submit Offer (User/Seller)
        [HttpPost]
        public async Task<IActionResult> SubmitOffer([FromBody] PropertyOffer offer)
        {
            await _propertyOfferRepository.AddOfferAsync(offer);
            return Ok(new { message = "Offer submitted for review." });
        }


        // 🔵 Get Pending Offers (Property Manager)
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<PropertyOffer>>> GetPendingOffers()
        {
            var offers = await _propertyOfferRepository.GetPendingOffersAsync();
            return Ok(offers);
        }

        // 🟢 Accept Offer (Property Manager)
        [HttpPut("accept/{id}")]
        public async Task<IActionResult> AcceptOffer(int id)
        {
            var success = await _propertyOfferRepository.AcceptOfferAsync(id);
            if (!success) return NotFound("Offer not found.");
            return Ok(new { message = "Offer accepted. Property is now listed." });
        }

        // 🔴 Decline Offer (Property Manager)
        [HttpDelete("decline/{id}")]
        public async Task<IActionResult> DeclineOffer(int id)
        {
            var success = await _propertyOfferRepository.DeclineOfferAsync(id);
            if (!success) return NotFound("Offer not found.");
            return Ok(new { message = "Offer declined and removed." });
        }
    }
}
