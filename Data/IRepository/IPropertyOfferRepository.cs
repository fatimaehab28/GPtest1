using System.Collections.Generic;
using System.Threading.Tasks;
using tbackendgp.Models;

namespace tbackendgp.Data.IRepository
{
    public interface IPropertyOfferRepository
    {
        Task<IEnumerable<PropertyOffer>> GetPendingOffersAsync();
        Task<PropertyOffer> GetOfferByIdAsync(int id);
        Task AddOfferAsync(PropertyOffer offer);
        Task<bool> AcceptOfferAsync(int offerId);
        Task<bool> DeclineOfferAsync(int offerId);
    }
}
