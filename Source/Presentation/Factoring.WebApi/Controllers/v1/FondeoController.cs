using Factoring.Application.Features.Fondeo.Commands;
using Factoring.Application.Features.Fondeo.Queries.FondeoGetAll;
using Factoring.Application.Features.Fondeo.Queries.FondeoReport;
using Factoring.Application.Features.Fondeo.Queries.FondeoSearch;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FondeoController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(InsertFondeoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateFondeoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("update-state")]
        public async Task<IActionResult> UpdateState(UpdateEstadoFondeoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("lista-fondeo")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new FondeoGetAllQuery { }));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetFondeoListAll filter)
        {
            return Ok(await Mediator.Send(filter));
        }
        [HttpGet("get-registro-fondeo-base64")]
        public async Task<IActionResult> GetDowloadRegistroFondeo([FromQuery] GetFondeoGetDataTableDonwloadQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
