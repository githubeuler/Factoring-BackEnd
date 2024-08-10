using Factoring.Application.Features.FondeadorDetails.Documentos.Commands.CreateDocumentoFondeador;
using Factoring.Application.Features.FondeadorDetails.Documentos.Commands.DeleteDocumentoFondeador;
using Factoring.Application.Features.FondeadorDetails.Documentos.Querys.GetAllFondeadorByIdFondeador;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FondeadorDocumentoController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateFondeadorDocumentoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteDocumentoFondeadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentosByIdGirador(int id)
        {
            return Ok(await Mediator.Send(new GetAllDocumentoByIdFondeadorQuery()
            {
                Id = id
            }));
        }
    }
}
