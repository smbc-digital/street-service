using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockportGovUK.AspNetCore.Attributes.TokenAuthentication;
using StockportGovUK.NetStandard.Models.Enums;
using street_service.Exceptions;
using street_service.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace street_service.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [ApiController]
    [TokenAuthentication]
    public class StreetController : ControllerBase
    {
        private readonly IStreetService _streetService;

        private readonly ILogger<StreetController> _logger;

        public StreetController(IStreetService streetService, ILogger<StreetController> logger)
        {
            _streetService = streetService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{streetProvider}/{searchTerm}")]
        public async Task<IActionResult> Get(EStreetProvider streetProvider, string searchTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var stopwatch = Stopwatch.StartNew();
                var result = await _streetService.SearchAsync(streetProvider, searchTerm);
                _logger.LogWarning($"StreetService:StreetController: received request, provider: {streetProvider} term {searchTerm} - Processing time : {stopwatch.Elapsed.TotalSeconds}");
                return Ok(result);                
            }
            catch(ProviderException e)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}