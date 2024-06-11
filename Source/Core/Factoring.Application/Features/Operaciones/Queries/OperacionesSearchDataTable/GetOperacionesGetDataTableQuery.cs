using AutoMapper;
using MediatR;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Operaciones.Queries.OperacionesSearchDataTable
{
    public class GetOperacionesGetDataTableQuery : IRequest<Response<IReadOnlyList<OperacionesResponseDataTable>>>
    {
        public int Pageno { get; set; }
        public string ? FilterNroOperacion { get; set; }
        public string ? FilterRazonGirador { get; set; }
        public string? FilterRazonAdquiriente { get; set; }
        public string? FilterFecCrea { get; set; }
        public string? Estado { get; set; }
        public string? Usuario { get; set; }
        public int PageSize { get; set; }
        public string? Sorting { get; set; }
        public string? SortOrder { get; set; }

        public class GetOperacionesGetDataTableQueryHandler : IRequestHandler<GetOperacionesGetDataTableQuery, Response<IReadOnlyList<OperacionesResponseDataTable>>>
        {
            private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;
            private readonly IMapper _mapper;
            public GetOperacionesGetDataTableQueryHandler(IOperacionesRepositoryAsync operacionesRepositoryAsync, IMapper mapper)
            {
                _operacionesRepositoryAsync = operacionesRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<OperacionesResponseDataTable>>> Handle(GetOperacionesGetDataTableQuery query, CancellationToken cancellationToken)
            {

                var request = _mapper.Map<OperacionesRequestDataTableDto>(query);

                var giradorList = await _operacionesRepositoryAsync.GetListOperaciones(request);

                return new Response<IReadOnlyList<OperacionesResponseDataTable>>(giradorList);
            }
        }

    }
}
