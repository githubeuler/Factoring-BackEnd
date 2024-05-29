using Factoring.Application.Features.Girador.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class GiradorController : BaseApiController
    {
        [HttpGet("lista")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GiradorListQuery { }));
        }
    }
}
