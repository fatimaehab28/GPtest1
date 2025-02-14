using System.Collections.Generic;
using System.Threading.Tasks;
using tbackendgp.Models;

namespace tbackendgp.Data.IRepository
{
    public interface IPropertyRepository : IDataRepository<Property>
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);

        // Filters based on property status
        Task<IEnumerable<Property>> GetAvailablePropertiesAsync(); // Based on SellingStatus
        Task<IEnumerable<Property>> GetPropertiesBySellingStatusAsync(string sellingStatus);
        Task<IEnumerable<Property>> GetPropertiesByFundingStatusAsync(string fundingStatus);
        Task<IEnumerable<Property>> GetPropertiesByRentingStatusAsync(string rentingStatus);

        // Other property filters
        Task<IEnumerable<Property>> GetPropertiesByTypeAsync(string propertyType);

        // CRUD Operations
        Task AddPropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(int id);
    }
}
