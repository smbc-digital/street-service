﻿global using System.Net.Mime;
global using System.Reflection;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.OpenApi.Models;
global using Serilog;
global using StockportGovUK.AspNetCore.Attributes.TokenAuthentication;
global using StockportGovUK.AspNetCore.Logging.Elasticsearch.Aws;
global using StockportGovUK.NetStandard.Gateways.Enums;
global using StockportGovUK.NetStandard.Gateways.Extensions;
global using StockportGovUK.NetStandard.Gateways.Models.Addresses;
global using StockportGovUK.NetStandard.Gateways.VerintService;
global using street_service.Exceptions;
global using street_service.Providers;
global using street_service.Services;
global using street_service.Utils.HealthChecks;
global using street_service.Utils.ServiceCollectionExtensions;