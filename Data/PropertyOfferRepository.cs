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

        // 🔵 Accept Offer & Move Property to Public Listings
        public async Task<bool> AcceptOfferAsync(int offerId)
        {
            var offer = await _context.PropertyOffers.FindAsync(offerId);
            if (offer == null) return false;

            // 🟢 Move Offer Data to Properties Table
            var property = new Property
            {
                PropertyName = offer.PropertyName,
                PropertyType = offer.PropertyType,
                PropertyAddress = offer.PropertyAddress,
                NumberOfInvestors = offer.NumberOfInvestors,
                PropertyPrice = offer.PropertyPrice,
                SellingStatus = "Available",
                FundingStatus = "Funding",
                RentingStatus = "Not Rented",
                FundingPercentage = offer.FundingPercentage,
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
