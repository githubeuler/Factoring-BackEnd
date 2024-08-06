using Factoring.Application.Features.FondeadorDetails.Cavali.Commands.CreateCavaliFondeador;
using Factoring.Application.Features.FondeadorDetails.Cavali.Commands.DeleteCavaliFondeador;
using Factoring.Application.Features.FondeadorDetails.Cavali.Querys.GetAllCavaliByIdFondeador;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FondeadorCavaliController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateFondeadorCavaliCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllContactoByIdFondeador(int id)
        {
            return Ok(await Mediator.Send(new GetAllCavaliByIdFondeadorQuery()
            {
                Id = id
            }));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteCavaliFondeadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
