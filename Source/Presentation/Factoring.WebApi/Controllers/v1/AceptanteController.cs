using Factoring.Application.Features.Aceptante.Commands;
using Factoring.Application.Features.Aceptante.Queries;
using Factoring.Application.Features.Adquiriente.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class AceptanteController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAdquirienteListAll filter)
        {
            return Ok(await Mediator.Send(filter));
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateAceptanteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteAceptanteByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAceptanteByIdQuery { Id = id }));
        }


    }
}
