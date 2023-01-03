namespace street_service.Providers;

public class VerintStreetProvider : IStreetProvider
{
    public EStreetProvider ProviderName => EStreetProvider.CRM;

    private readonly IVerintServiceGateway _verintServiceGateway;

    public VerintStreetProvider(IVerintServiceGateway verintServiceGateway) => _verintServiceGateway = verintServiceGateway;

    public async Task<IEnumerable<AddressSearchResult>> SearchAsync(string street)
    {
        var response = await _verintServiceGateway.GetStreetByReference(street);
        return response.ResponseContent;
    }
}