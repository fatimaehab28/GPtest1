using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tbackendgp.Data;
using tbackendgp.Data.IRepository;
using tbackendgp.Models;

namespace tbackendgp.Data
{
    public class PropertyRepository : DataRepository<Property>, IPropertyRepository
    {
        private readonly DataContext _context;

        public PropertyRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        // 🟢 Get All Properties
        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        // 🔵 Get Property By ID
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }

        // 🟢 Get Available Properties (Based on SellingStatus)
        public async Task<IEnumerable<Property>> GetAvailablePropertiesAsync()
        {
            return await _context.Properties.Where(p => p.SellingStatus == "Available").ToListAsync();
        }

        // 🔵 Get Properties By Type
        public async Task<IEnumerable<Property>> GetPropertiesByTypeAsync(string propertyType)
        {
            return await _context.Properties.Where(p => p.PropertyType == propertyType).ToListAsync();
        }

        // 🟢 Get Properties By Selling Status
        public async Task<IEnumerable<Property>> GetPropertiesBySellingStatusAsync(string sellingStatus)
        {
            return await _context.Properties.Where(p => p.SellingStatus == sellingStatus).ToListAsync();
        }

        // 🟢 Get Properties By Funding Status
        public async Task<IEnumerable<Property>> GetPropertiesByFundingStatusAsync(string fundingStatus)
        {
            return await _context.Properties.Where(p => p.FundingStatus == fundingStatus).ToListAsync();
        }

        // 🟢 Get Properties By Renting Status
        public async Task<IEnumerable<Property>> GetPropertiesByRentingStatusAsync(string rentingStatus)
        {
            return await _context.Properties.Where(p => p.RentingStatus == rentingStatus).ToListAsync();
        }

        // 🔴 Add Property (CREATE)
        public async Task AddPropertyAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
        }

        // 🔵 Update Property
        public async Task UpdatePropertyAsync(Property property)
        {
            var existingProperty = await _context.Properties.FindAsync(property.Id);
            if (existingProperty != null)
            {
                _context.Entry(existingProperty).CurrentValues.SetValues(property); // 🟢 Ensures tracking
                await _context.SaveChangesAsync();
            }
        }

        // 🔴 Delete Property
        public async Task<bool> DeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
                return false;

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
