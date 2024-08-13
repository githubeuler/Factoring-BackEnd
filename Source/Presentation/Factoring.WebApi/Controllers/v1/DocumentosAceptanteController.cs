using Factoring.Application.Features.DocumentosAceptante.Commands;
using Factoring.Application.Features.DocumentosAceptante.Queries;
using Factoring.Application.Features.GiradorDetails.Documentos.Commands.GiradorDocumentoDeleteCommand;
using Factoring.Application.Features.GiradorDetails.Documentos.Commands.GiradorDocumentoInsertCommand;
using Factoring.Application.Features.GiradorDetails.Documentos.Querys.GiradorDocumentoListQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class DocumentosAceptanteController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(AceptanteDocumentoInsertCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] AceptanteDocumentoDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentosByIdGirador(int id)
        {
            return Ok(await Mediator.Send(new AceptanteDocumentoListQuery()
            {
                Id = id
            }));
        }

    }
}
