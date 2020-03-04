using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Enums;
using street_service.Exceptions;
using street_service.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace street_service.Services
{
    public interface IStreetService 
    {
        Task<IEnumerable<AddressSearchResult>> SearchAsync(EStreetProvider streetProvider, string searchTerm);
    }

    public class StreetService : IStreetService
    {
        private readonly IEnumerable<IStreetProvider> _streetProviders;
        private readonly ILogger<IStreetProvider> _logger;

        public StreetService(IEnumerable<IStreetProvider> streetProviders, ILogger<IStreetProvider> logger)
        {
            _logger = logger;
            _streetProviders = streetProviders;
        }

        public async Task<IEnumerable<AddressSearchResult>> SearchAsync(EStreetProvider streetProvider, string searchTerm)
        {
            var provider = _streetProviders.ToList()
                .Where(_ => _.ProviderName == streetProvider)
                .FirstOrDefault();

            if (provider == null)
            {
                throw new Exception();
            }

            switch (streetProvider)
            {
                case EStreetProvider.Fake:
                    return await provider.SearchAsync(searchTerm);
                case EStreetProvider.CRM:
                    return await provider.SearchAsync(searchTerm);
                default:
                    throw new ProviderException("SearchAsync: No provider selected to perform search operation");
            }
        }
    }
}
