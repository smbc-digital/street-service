using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace street_service.Providers
{
    public class FakeStreetProvider : IStreetProvider
    {
        public EStreetProvider ProviderName => EStreetProvider.Fake;

        public async Task<IEnumerable<AddressSearchResult>> SearchAsync(string street)
        {
            return new List<AddressSearchResult> {
                new AddressSearchResult {
                    Name = "Green lane",
                    UniqueId = "123456789012"
                },
                 new AddressSearchResult {
                    Name = "Green road",
                    UniqueId = "098765432109"
                },
                 new AddressSearchResult {
                    Name = "Green street",
                    UniqueId = "564737838937"
                }
            };
        }
    }
}
