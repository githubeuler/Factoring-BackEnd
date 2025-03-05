using Factoring.Application.Features.Operaciones.Commands;
using Factoring.Application.Features.Operaciones.Commands.UpdateOperacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Factoring.Application.Features.Condiciones.Command;
//using Factoring.Application.Features.Condiciones.Queries;
//using Factoring.Application.Features.EvaluacionOperaciones.Alert;
//using Factoring.Application.Features.EvaluacionOperaciones.Commands.CreateEvaluacionOperacionCommand;
//using Factoring.Application.Features.EvaluacionOperaciones.Queries.EvaluacionOperacionesComercialSingleQuery;
//using Factoring.Application.Features.EvaluacionOperaciones.Queries.EvaluacionOperacionesListDataTable;
//using Factoring.Application.Features.EvaluacionOperaciones.Queries.EvaluacionOperacionesSingleQuery;
//using Factoring.Application.Features.EvaluacionOperaciones.Queries.PreEvaluacionOperacionesListDataTable;
//using Factoring.Application.Features.ResultadoEvaluacionOperacion.Queries;
//using Factoring.Application.Features.SolicitudEvaluacionOperacion;
using System.Threading.Tasks;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class EstadosOperacionController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateEvaluacionOperacionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("estado-facura")]
        public async Task<IActionResult> PostFactura(CreateEstadoFacturaOperacionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("update-facura-calculo")]
        public async Task<IActionResult> PostCalculoFactura(UpdateEvaluacionOperacionCalculoCommand command)
        {
            return Ok(await Mediator.Send(command));

        }
        [HttpPost("generate-facura-calculo")]
        public async Task<IActionResult> PostGenerateCalculoFactura(GenerateFacturaCalculoCommand command)
        {
            return Ok(await Mediator.Send(command));

        }
    }
}
