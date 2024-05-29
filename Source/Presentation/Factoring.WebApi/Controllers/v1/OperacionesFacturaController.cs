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

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class OperacionesFacturaController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllRepresentanteLegalByIdGirador(int id)
        {
            return Ok(await Mediator.Send(new GetAllFacturasByOperacionQuery()
            {
                Id = id
            }));
        }

    }
}
