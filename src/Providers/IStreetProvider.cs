namespace street_service.Providers;

public interface IStreetProvider
{
    EStreetProvider ProviderName { get; }
    Task<IEnumerable<AddressSearchResult>> SearchAsync(string street);
}