using Factoring.Application.Features.AdquirienteDetails.AdquirienteUbicacion.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class UbicacionAdquirienteController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateAdquirienteUbicacionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteAdquirienteUbicacionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAllAdquirienteUbicacion(int id)
        //{
        //    return Ok(await Mediator.Send(new GetAllAdquirienteUbicacionQuery()
        //    {
        //        Id = id
        //    }));
        //}
    }
}
