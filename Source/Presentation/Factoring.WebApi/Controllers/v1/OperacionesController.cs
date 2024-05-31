using Factoring.Application.Features.Operaciones.Commands;
using Factoring.Application.Features.Operaciones.Queries.OperacionesGetByidQuery;
using Factoring.Application.Features.Operaciones.Queries.OperacionesSearchDataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class OperacionesController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateOperacionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetOperacionesGetDataTableQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new OperacionesGetByidQuery { Id = id }));
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateOperacionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
