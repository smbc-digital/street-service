using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace street_service.Providers
{
    public interface IStreetProvider
    {
        EStreetProvider ProviderName { get; }
        Task<IEnumerable<AddressSearchResult>> SearchAsync(string street);
    }
}
