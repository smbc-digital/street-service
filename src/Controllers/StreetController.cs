using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockportGovUK.AspNetCore.Attributes.TokenAuthentication;
using StockportGovUK.NetStandard.Models.Enums;
using street_service.Exceptions;
using street_service.Services;
using System;
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
                return BadRequest();

            try
            {
                var result = await _streetService.SearchAsync(streetProvider, searchTerm);
                return Ok(result);                
            }
            catch(ProviderException ex)
            {
                _logger.LogWarning($"StreetService:StreetController {ex.Message}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"StreetService:StreetController {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}