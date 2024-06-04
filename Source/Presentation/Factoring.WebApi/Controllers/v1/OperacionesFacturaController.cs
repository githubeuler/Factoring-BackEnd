using Microsoft.AspNetCore.Mvc;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
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
