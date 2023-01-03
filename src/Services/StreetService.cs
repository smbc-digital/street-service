namespace street_service.Services;

public interface IStreetService 
{
    Task<IEnumerable<AddressSearchResult>> SearchAsync(EStreetProvider streetProvider, string searchTerm);
}

public class StreetService : IStreetService
{
    private readonly IEnumerable<IStreetProvider> _streetProviders;

    public StreetService(IEnumerable<IStreetProvider> streetProviders) => _streetProviders = streetProviders;

    public async Task<IEnumerable<AddressSearchResult>> SearchAsync(EStreetProvider streetProvider, string searchTerm)
    {
        var provider = _streetProviders.ToList()
            .Where(_ => _.ProviderName == streetProvider)
            .FirstOrDefault();

        if (provider is null)
            throw new Exception();

        return streetProvider switch
        {
            EStreetProvider.Fake => await provider.SearchAsync(searchTerm),
            EStreetProvider.CRM => await provider.SearchAsync(searchTerm),
            _ => throw new ProviderException("SearchAsync: No provider selected to perform search operation")
        };
    }
}