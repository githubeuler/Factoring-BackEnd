using Microsoft.AspNetCore.Mvc;
using Factoring.Application.DTOs.Operaciones;
//using Factoring.Application.Features.EvaluacionOperaciones.Commands.UpdateOperacionesCommand;
//using Factoring.Application.Features.Operaciones.Commands.CreateOperacion;
//using Factoring.Application.Features.Operaciones.Commands.DeleteOperacion;
//using Factoring.Application.Features.Operaciones.Commands.UpdateOperacion;
//using Factoring.Application.Features.Operaciones.Commands.UpdateOperacionesEstado;
//using Factoring.Application.Features.Operaciones.Queries.OperacionesComentariosAllQuery;
//using Factoring.Application.Features.Operaciones.Queries.OperacionesGetByidQuery;
using Factoring.Application.Features.Operaciones.Queries.OperacionesSearchDataTable;
//using Factoring.Application.Features.Operaciones.Queries.OperacionesGetByidReporteCavali;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
//using Factoring.Application.Features.Operaciones.Commands.ActualizaOperacionesFactura;
//using Factoring.Application.Features.Operaciones.Queries.OperacionInvoiceCavali;
//using Factoring.Application.Features.Operaciones.Queries.OperacionesTransferenciasGetAll;
//using Factoring.Application.Features.Operaciones.Queries.OperacionGetFondeadorQuery;
//using Factoring.Application.Features.Operaciones.Commands.MasivoOperacionCommand;

//using Factoring.Application.Features.Cavali.Querys;
//using Factoring.Application.Features.DivisoService.Queries;
using Microsoft.AspNetCore.Http;
//using Factoring.Application.Features.Operaciones.Commands.MasivoLoteCommand;
//using Factoring.Application.Features.Operaciones.Commands.CreateSolicitudOperacion;
//using Factoring.Application.Features.OperacionesFacturas.Queries.GetAllCavaliByOperacionQuery;
//using Factoring.Application.DTOs.Operaciones.OperacionesLote;
using System.Xml;
using System.IO;
using Factoring.Application.Features.Operaciones.Queries.OperacionesGetByidQuery;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class OperacionesController : BaseApiController
    {

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

    }
}
