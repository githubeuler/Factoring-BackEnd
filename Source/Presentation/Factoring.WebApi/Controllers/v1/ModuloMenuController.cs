using Factoring.Application.Features.Aceptante.Commands;
using Factoring.Application.Features.Aceptante.Queries;
using Factoring.Application.Features.Adquiriente.Commands;
using Factoring.Application.Features.Adquiriente.Queries;
using Factoring.Application.Features.AdquirienteDetails.AdquirienteUbicacion.Commands;
using Factoring.Application.Features.ModuloMenu.Commands;
using Factoring.Application.Features.ModuloMenu.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class ModuloMenuController : BaseApiController
    {
        [HttpGet("get-perfil")]
        public async Task<IActionResult> GetPerfil([FromQuery] GetListPerfilListQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }
        [HttpGet("get-menu-modulo")]
        public async Task<IActionResult> GetMenuModulo([FromQuery] ModuloMenuListQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateModuloMenuCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("update-perfil")]
        public async Task<IActionResult> PostUpdate(UpdateModuloMenuCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("get-perfil-edit")]
        public async Task<IActionResult> GetPerfilEdit([FromQuery] GetListEditPerfilListQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }

    }
}
