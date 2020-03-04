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

Implementation is almost identical to that described in the AddressProvider

Register for use 

```c#
services.AddSingleton<IStreetProvider, FakeStreetProvider>();
services.AddSingleton<IStreetProvider, CRMStreetProvider>();
return services;
```

Specify which street provider to use.

```json
"Elements": [
  {
    "Type": "Street",
    "Properties": {
      "QuestionId": "customersstreet",
      "StreetProvider": "Fake",
    }
```
