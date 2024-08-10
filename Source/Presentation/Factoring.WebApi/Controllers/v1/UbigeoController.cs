using Factoring.Application.Features.Ubigeo.Queries.GetSpecifiedLocationForCountry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class UbigeoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSpecifiedLocationForCountryQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
