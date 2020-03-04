<h1 align="center">Street Service</h1>
<div align="center">🛣️:pencil2::books:</div>
<div align="center">
  <sub>Built with ❤︎ by
  <a href="https://www.stockport.gov.uk">Stockport Council</a>
</div>


## Table of Contents
- [Requirements & Prereqs](#requirements-&-prereqs)
- [Payment Providers](#payment-providers)

# Requirements & Prereqs
- dotnet core 2.2

## Street Providers

`IStreetProvider` is provided to enable integration with different street level data sources. 

The interface requires a ProviderName and a SearchAsync method which must return an `AddressSearchResult` object. 

```c#
EStreetProvider ProviderName { get; }

Task<IEnumerable<AddressSearchResult>> SearchAsync(EStreetProvider streetProvider, string searchTerm);
```

You can register new/multiple street providers in startup 

```c#
services.AddSingleton<IStreetProvider, FakeStreetProvider>();
services.AddSingleton<IStreetProvider, CRMStreetProvider>();
services.AddSingleton<IStreetProvider, MyCustomStreetProvider>();
```
