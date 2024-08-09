using Microsoft.AspNetCore.Mvc;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Factoring.Application.Features.OperacionesFacturas.Queries;
using Factoring.Application.Features.OperacionesFacturas.Commands;
using Factoring.Application.Features.OperacionesFacturas.Queries.GetAllFacturasByOperacionQuery;
using Factoring.Application.Features.OperacionesFacturas.Queries.ValidateEstadoOperacionesFacturasQuery;
using Factoring.Application.Features.OperacionesFacturas.Queries.InvoicesCavaliSendQuery;

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
        [HttpPost("edit-monto")]
        public async Task<IActionResult> EditMonto(EditOperacionFacturaMontoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("bandeja-factura")]
        public async Task<IActionResult> Get([FromQuery] GetFacturasDataTableQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }

        [HttpPost("ValidateEstadoOperacionFactura")]
        public async Task<IActionResult> ValidateEstadoOperacionFactura(OperacionesFacturaListDto OperacionFactura)
        {
            return Ok(await Mediator.Send(new ValidateEstadoOperacionesFacturasQuery()
            {
                IdOperacionFactura = OperacionFactura.nIdOperacionesFacturas,
                tipoOperacion = OperacionFactura.nEstado
            }));
        }

        [HttpPost("validate-asignacion-inversionista")]
        public async Task<IActionResult> GetFondeador(OperacionFacturaValidateGetFondeadorQuery model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPost("invoices-cavaly-send")]
        public async Task<IActionResult> SendInvoicesCavali(InvoicesCavaliSendQuery model)
        {
            return Ok(await Mediator.Send(model));
        }
        [HttpPost("remove-cavaly-send")]
        public async Task<IActionResult> SendRemoveCavali(RemoveCavaliSendQuery model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPost("redeem-cavaly-send")]
        public async Task<IActionResult> SendRedeemCavali(RedeemCavaliSendQuery model)
        {
            return Ok(await Mediator.Send(model));
        }

    }
}
