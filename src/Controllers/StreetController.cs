using Microsoft.AspNetCore.Mvc;
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

        public StreetController(IStreetService streetService)
        {
            _streetService = streetService;
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
                var result = await _streetService.SearchAsync(streetProvider, searchTerm);
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