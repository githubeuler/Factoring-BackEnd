using Microsoft.AspNetCore.Mvc;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
//using Factoring.Application.Features.Operaciones.Commands.CreateDocumentoSolicitudOperaciones;
//using Factoring.Application.Features.Operaciones.Commands.DeleteOperacion;
//using Factoring.Application.Features.Operaciones.Commands.GetDocumentoSolicitudByAll;
//using Factoring.Application.Features.Operaciones.Queries.OperacionGetFondeadorQuery;
//using Factoring.Application.Features.OperacionesFacturas.Commands.CreateOperacionFacturaCommand;
//using Factoring.Application.Features.OperacionesFacturas.Commands.CreateOperacionFacturaMasivoCommand;
//using Factoring.Application.Features.OperacionesFacturas.Commands.DeleteOperacionFacturaCommand;
//using Factoring.Application.Features.OperacionesFacturas.Commands.EditOperacionFacturaCommand;
//using Factoring.Application.Features.OperacionesFacturas.Queries.GetAllFacturasByOperacionFacturaQuery;
//using Factoring.Application.Features.OperacionesFacturas.Queries.GetAllFacturasByOperacionQuery;
//using Factoring.Application.Features.OperacionesFacturas.Queries.GetFacturaBandejaQuery;
//using Factoring.Application.Features.OperacionesFacturas.Queries.GetFacturaByNumero;
//using Factoring.Application.Features.OperacionesFacturas.Queries.InvoicesCavaliSendQuery;
//using Factoring.Application.Features.OperacionesFacturas.Queries.ValidateEstadoOperacionesFacturasQuery;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Factoring.Application.Features.OperacionesFacturas.Queries;
using Factoring.Application.Features.OperacionesFacturas.Commands;
using Factoring.Application.Features.OperacionesFacturas.Queries.GetAllFacturasByOperacionQuery;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class OperacionesFacturaController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllRepresentanteLegalByIdGirador(int id)
        {
            return base.Ok(await Mediator.Send(new GetAllFacturasByOperacionFacturaQuery()
            {
                Id = id
            }));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateOperacionFacturaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteOperacionFacturaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(EditOperacionFacturaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("GetInvoiceByNumber/{idGirador}/{idAdquiriente}/{nroFactura}")]
        public async Task<IActionResult> GetInvoiceByNumber(int idGirador, int idAdquiriente, string nroFactura)
        {
            return Ok(await Mediator.Send(new GetFacturaByNumero { IdGirador = idGirador, IdAdquiriente = idAdquiriente, NroFactura = nroFactura }));
        }
        [HttpPost("consultar-factura")]
        public async Task<IActionResult> ConsultarFactura(GetIdAllFacturasByOperacionFacturaQuery model)
        {
            return Ok(await Mediator.Send(model));
        }
    }
}
