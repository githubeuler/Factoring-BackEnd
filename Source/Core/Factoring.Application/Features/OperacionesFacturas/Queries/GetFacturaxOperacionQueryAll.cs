using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
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
    public class GetFacturaxOperacionQueryAll : IRequest<Response<IReadOnlyList<OperacionFacturaResponseDto>>>
    {
        public int nIdOperacion { get; set; }

        public class GetFacturaxOperacionQueryAllHandler : IRequestHandler<GetFacturaxOperacionQueryAll, Response<IReadOnlyList<OperacionFacturaResponseDto>>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            public GetFacturaxOperacionQueryAllHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }
            public async Task<Response<IReadOnlyList<OperacionFacturaResponseDto>>> Handle(GetFacturaxOperacionQueryAll query, CancellationToken cancellationToken)
            {
                var facturaData = await _operacionesFacturaRepositoryAsync.GetListFacturasxOperacion(query.nIdOperacion);
                return new Response<IReadOnlyList<OperacionFacturaResponseDto>>(facturaData);
            }
        }
    }
}