using Factoring.Application.Features.AceptanteContacto.Commands;
using Factoring.Application.Features.AceptanteContacto.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class AceptanteContactoController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> Post(CreateContactoAceptanteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteContactoAceptanteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllContactoByIdGirador(int id)
        {
            return Ok(await Mediator.Send(new GetAllContactoByIdAceptanteQuery()
            {
                Id = id
            }));
        }
    }
}
