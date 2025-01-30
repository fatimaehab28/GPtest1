using System.Collections.Generic;
using System.Threading.Tasks;
using tbackendgp.Models;

namespace tbackendgp.Data.IRepository
{
    public interface IPropertyRepository : IDataRepository<Property>
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task<IEnumerable<Property>> GetAvailablePropertiesAsync();
        Task<IEnumerable<Property>> GetPropertiesByTypeAsync(string propertyType);
        Task<IEnumerable<Property>> GetPropertiesByStatusAsync(string status);
        Task AddPropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(int id);
    }
}
