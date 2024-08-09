using Factoring.Application.Features.Fondeador.Queries.FondeadorGetAll;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FondeadorController : BaseApiController
    {
        [HttpGet("lista-fondeadores")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new FondeadorGetAllQuery { }));
        }
    }
}
