using Factoring.Application.Features.Aceptante.Commands;
using Factoring.Application.Features.Adquiriente.Commands;
using Factoring.Application.Features.Adquiriente.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class AdquirienteController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateAdquirienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateAceptanteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("lista")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new AdquirienteListQuery { }));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAdquirienteListAll filter)
        {
            return Ok(await Mediator.Send(filter));
        }
    }
}
