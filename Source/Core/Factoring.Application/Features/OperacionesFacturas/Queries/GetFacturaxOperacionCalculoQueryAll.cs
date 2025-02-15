using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.DTOs.OperacionesFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Queries
{
    public class GetFacturaxOperacionCalculoQueryAll : IRequest<Response<IReadOnlyList<OperacionesFacturaCalculoDto>>>
    {
        public int nIdOperacion { get; set; }

        public class GetFacturaxOperacionCalculoQueryAllHandler : IRequestHandler<GetFacturaxOperacionCalculoQueryAll, Response<IReadOnlyList<OperacionesFacturaCalculoDto>>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            public GetFacturaxOperacionCalculoQueryAllHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }
            public async Task<Response<IReadOnlyList<OperacionesFacturaCalculoDto>>> Handle(GetFacturaxOperacionCalculoQueryAll query, CancellationToken cancellationToken)
            {
                var facturaData = await _operacionesFacturaRepositoryAsync.GetAllOperacionesFacturasCalculo(query.nIdOperacion);
                return new Response<IReadOnlyList<OperacionesFacturaCalculoDto>>(facturaData);
            }
        }
    }
}
