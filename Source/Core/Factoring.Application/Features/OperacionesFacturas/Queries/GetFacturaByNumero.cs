using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.OperacionesFacturas.Queries
{
    public class GetFacturaByNumero : IRequest<Response<OperacionesFacturaListDto>>
    {
        public int IdGirador { get; set; }
        public int IdAdquiriente { get; set; }
        public string NroFactura { get; set; }
        public class GetFacturaByNumeroQueryHandler : IRequestHandler<GetFacturaByNumero, Response<OperacionesFacturaListDto>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;

            public GetFacturaByNumeroQueryHandler(
                IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync
                )
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }

            public async Task<Response<OperacionesFacturaListDto>> Handle(GetFacturaByNumero query, CancellationToken cancellationToken)
            {
                var factura = await _operacionesFacturaRepositoryAsync.FindByNumberAsync(query.IdGirador,query.IdAdquiriente, query.NroFactura);
                if (factura == null) throw new ApiException($"Factura no encontrada.");

                return new Response<OperacionesFacturaListDto>(factura);
            }
        }
    }
}
