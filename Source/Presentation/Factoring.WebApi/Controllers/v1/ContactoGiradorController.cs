using Factoring.Application.Features.GiradorDetails.Contacto.Commands.CreateContactoGirador;
using Factoring.Application.Features.GiradorDetails.Contacto.Commands.DeleteContactoGirador;
using Factoring.Application.Features.GiradorDetails.Contacto.Querys.GetAllContactoByIdGirador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class ContactoGiradorController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateGiradorContactoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteContactoGiradorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllContactoByIdGirador(int id)
        {
            return Ok(await Mediator.Send(new GetAllContactoByIdGirador()
            {
                Id = id
            }));
        }
    }
}
