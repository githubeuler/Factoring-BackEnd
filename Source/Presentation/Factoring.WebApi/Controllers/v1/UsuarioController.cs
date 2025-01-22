
using Factoring.Application.Features.Usuario.Commands;
using Factoring.Application.Features.Usuario.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class UsuarioController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("obtener-usuario/{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            return Ok(await Mediator.Send(new GetUsuarioByIdQuery { IdUsuario = id }));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUsuarioListAll filter)
        {
            return Ok(await Mediator.Send(filter));
        }
    }
}
