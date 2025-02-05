using AutoMapper;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Queries
{
    public class GetFacturasDataTableQuery : IRequest<Response<IReadOnlyList<OperacionesFacturaResponseDataTable>>>
    {
        public int? Pageno { get; set; }
        public string? FilterNroOperacion { get; set; }
        public int? PageSize { get; set; }
        public string? Sorting { get; set; }
        public string? SortOrder { get; set; }
        public int? nEstado { get; set; }
        public string? FechaCreacion { get; set; }
        public string Usuario { get; set; }

        public class GetFacturasDataTableQueryHandler : IRequestHandler<GetFacturasDataTableQuery, Response<IReadOnlyList<OperacionesFacturaResponseDataTable>>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            private readonly IMapper _mapper;
            public GetFacturasDataTableQueryHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync, IMapper mapper)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<OperacionesFacturaResponseDataTable>>> Handle(GetFacturasDataTableQuery query, CancellationToken cancellationToken)
            {
                var request = _mapper.Map<OperacionesFacturaRequestDataTableDto>(query);
                var facturaData = await _operacionesFacturaRepositoryAsync.GetListFacturasBandeja(request);
                return new Response<IReadOnlyList<OperacionesFacturaResponseDataTable>>(facturaData);
            }
        }

    }
}

