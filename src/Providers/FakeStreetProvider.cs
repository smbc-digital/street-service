namespace street_service.Providers;

public class FakeStreetProvider : IStreetProvider
{
    public EStreetProvider ProviderName => EStreetProvider.Fake;

    public async Task<IEnumerable<AddressSearchResult>> SearchAsync(string street) => await Task.FromResult(new List<AddressSearchResult> {
        new() {
            Name = "Green lane",
            UniqueId = "123456789012"
        },
        new() {
            Name = "Green road",
            UniqueId = "098765432109"
        },
        new() {
            Name = "Green street",
            UniqueId = "564737838937"
        }
    });
}