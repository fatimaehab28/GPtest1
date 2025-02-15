using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
            // ✅ Convert FundingPercentage from 100-based to decimal (e.g., 25 → 0.25)
            offer.FundingPercentage /= 100m;

            await _propertyOfferRepository.AddOfferAsync(offer);
            return Ok(new { message = "Offer submitted for review." });
        }

        // 🔵 Get Pending Offers (Property Manager)
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<PropertyOffer>>> GetPendingOffers()
        {
            var offers = await _propertyOfferRepository.GetPendingOffersAsync();

            // ✅ Convert FundingPercentage from decimal to percentage for response (e.g., 0.25 → 25)
            var response = offers.Select(o => new PropertyOffer
            {
                OfferID = o.OfferID,
                UserID = o.UserID,
                PropertyName = o.PropertyName,
                PropertyType = o.PropertyType,

                // ✅ Send Address as an Object
                PropertyAddress = new Address
                {
                    Street = o.PropertyAddress.Street,
                    City = o.PropertyAddress.City,
                    State = o.PropertyAddress.State,
                    Country = o.PropertyAddress.Country
                },

                NumberOfInvestors = o.NumberOfInvestors,
                PropertyPrice = o.PropertyPrice,
                OfferStatus = o.OfferStatus,
                FundingPercentage = o.FundingPercentage * 100, // ✅ Convert to percentage
                NumOfRooms = o.NumOfRooms,
                NumOfBathrooms = o.NumOfBathrooms,
                PropertyArea = o.PropertyArea,
                FloorNumber = o.FloorNumber,
                ImageUrl = o.ImageUrl,
                PropertyOverview = o.PropertyOverview,
                PropertyLongitude = o.PropertyLongitude,
                PropertyLatitude = o.PropertyLatitude,
                CurrentRent = o.CurrentRent,
                ServiceFees = o.ServiceFees,
                ManagementFees = o.ManagementFees,
                MaintenanceFees = o.MaintenanceFees,
                OperatingExpenses = o.OperatingExpenses,
                OfferDate = o.OfferDate
            });

            return Ok(response);
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
