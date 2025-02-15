using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tbackendgp.Data;
using tbackendgp.Data.IRepository;
using tbackendgp.Models;

namespace tbackendgp.Data.Repository
{
    public class PropertyOfferRepository : IPropertyOfferRepository
    {
        private readonly DataContext _context;

        public PropertyOfferRepository(DataContext context)
        {
            _context = context;
        }

        // 🔵 Get All Pending Offers
        public async Task<IEnumerable<PropertyOffer>> GetPendingOffersAsync()
        {
            return await _context.PropertyOffers.Where(o => o.OfferStatus == "Pending").ToListAsync();
        }

        // 🔵 Get Offer By ID
        public async Task<PropertyOffer> GetOfferByIdAsync(int id)
        {
            return await _context.PropertyOffers.FindAsync(id);
        }

        // 🟢 Submit Offer
        public async Task AddOfferAsync(PropertyOffer offer)
        {
            _context.PropertyOffers.Add(offer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AcceptOfferAsync(int offerId)
        {
            var offer = await _context.PropertyOffers.FindAsync(offerId);
            if (offer == null) return false;

            // 🟢 Move Offer Data to Properties Table
            var property = new Property
            {
                PropertyName = offer.PropertyName,
                PropertyType = offer.PropertyType,

                // ✅ Copy Address Object Instead of a String
                PropertyAddress = new Address
                {
                    Street = offer.PropertyAddress.Street,
                    City = offer.PropertyAddress.City,
                    State = offer.PropertyAddress.State,
                    Country = offer.PropertyAddress.Country
                },

                NumberOfInvestors = offer.NumberOfInvestors,
                PropertyPrice = offer.PropertyPrice,
                SellingStatus = "Available",
                FundingStatus = "Funding",
                RentingStatus = "Not Rented",

                // ✅ Convert stored decimal (0.25) back to percentage (25)
                FundingPercentage = offer.FundingPercentage * 100,

                NumOfRooms = offer.NumOfRooms,
                NumOfBathrooms = offer.NumOfBathrooms,
                PropertyArea = offer.PropertyArea,
                FloorNumber = offer.FloorNumber,
                ImageUrl = offer.ImageUrl,
                PropertyOverview = offer.PropertyOverview,
                PropertyLongitude = offer.PropertyLongitude,
                PropertyLatitude = offer.PropertyLatitude,
                CurrentRent = offer.CurrentRent,
                ServiceFees = offer.ServiceFees,
                ManagementFees = offer.ManagementFees,
                MaintenanceFees = offer.MaintenanceFees,
                OperatingExpenses = offer.OperatingExpenses, // ✅ Added
                FundingDate = DateTime.UtcNow
            };

            _context.Properties.Add(property);

            // Update offer status instead of deleting
            offer.OfferStatus = "Accepted";

            await _context.SaveChangesAsync();
            return true;
        }


        // 🔴 Decline Offer
        public async Task<bool> DeclineOfferAsync(int offerId)
        {
            var offer = await _context.PropertyOffers.FindAsync(offerId);
            if (offer == null) return false;

            offer.OfferStatus = "Declined";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
