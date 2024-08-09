using AutoMapper;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Queries.ValidateEstadoOperacionesFacturasQuery
{
    public class ValidateEstadoOperacionesFacturasQuery : IRequest<Response<int>>
    {
        public int IdOperacionFactura { get; set; }
        public int tipoOperacion { get; set; }
    }

    public class ValidateEstadoOperacionesFacturasQueryHandler : IRequestHandler<ValidateEstadoOperacionesFacturasQuery, Response<int>>
    {
        private readonly IOperacionesFacturaRepositoryAsync _operacionesfARepositoryAsync;
        private readonly IMapper _mapper;

        public ValidateEstadoOperacionesFacturasQueryHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync, IMapper mapper)
        {
            _operacionesfARepositoryAsync = operacionesFacturaRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(ValidateEstadoOperacionesFacturasQuery request, CancellationToken cancellationToken)
        {
            var res = await _operacionesfARepositoryAsync.ValidateEstadoOperacionesFacturasAsync(request.IdOperacionFactura, request.tipoOperacion);
            return res;
        }
    }
}