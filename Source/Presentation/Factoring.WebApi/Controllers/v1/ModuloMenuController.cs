using Factoring.Application.Features.Aceptante.Commands;
using Factoring.Application.Features.Aceptante.Queries;
using Factoring.Application.Features.Adquiriente.Commands;
using Factoring.Application.Features.Adquiriente.Queries;
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
    }
}
