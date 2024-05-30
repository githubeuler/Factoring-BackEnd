using Factoring.Application.Features.Girador.Commands;
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
        [HttpPost]
        public async Task<IActionResult> Post(CreateGiradorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetGiradorListAll filter)
        {
            return Ok(await Mediator.Send(filter));
        }
        [HttpGet("lista")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GiradorListQuery { }));
        }
    }
}
