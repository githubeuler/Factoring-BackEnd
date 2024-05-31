using MediatR;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Factoring.Application.Features.OperacionesFacturas.Queries
{
    public class GetAllFacturasByOperacionFacturaQuery : IRequest<Response<IEnumerable<OperacionesFacturaListDto>>>
    {
        public int Id { get; set; }
        public class GetAllFacturasByOperacionFacturaQueryHandler : IRequestHandler<GetAllFacturasByOperacionFacturaQuery, Response<IEnumerable<OperacionesFacturaListDto>>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;

            public GetAllFacturasByOperacionFacturaQueryHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }

            public async Task<Response<IEnumerable<OperacionesFacturaListDto>>> Handle(GetAllFacturasByOperacionFacturaQuery query, CancellationToken cancellationToken)
            {
                var giradorDirecciones = await _operacionesFacturaRepositoryAsync.GetAllFacturasByOperaciones(query.Id);
                if (giradorDirecciones == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<OperacionesFacturaListDto>>(giradorDirecciones);
            }
        }
    }
}
