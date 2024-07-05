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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetGiradorByIdQuery { Id = id }));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateGiradorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPost("obtener-filename-documento")]
        public async Task<IActionResult> Post(GetGiradorDocumentosFileName command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
