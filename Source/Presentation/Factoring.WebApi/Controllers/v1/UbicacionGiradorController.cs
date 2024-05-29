using Factoring.Application.Features.GiradorDetails.GiradorUbicacion.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class UbicacionGiradorController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateGiradorUbicacionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteGiradorUbicacionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAllAdquirienteUbicacion(int id)
        //{
        //    return Ok(await Mediator.Send(new GetAllUbicacionByGiradorQuery()
        //    {
        //        Id = id
        //    }));
        //}
    }
}
