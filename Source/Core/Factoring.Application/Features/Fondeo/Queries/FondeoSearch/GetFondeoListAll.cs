using AutoMapper;
using Factoring.Application.DTOs.Fondeo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeo.Queries.FondeoSearch
{
    public class GetFondeoListAll : IRequest<Response<IReadOnlyList<FondeoResponseDataTable>>>
    {
        public int Pageno { get; set; }
        public string? FilterNroOperacion { get; set; }
        public string? FilterFondeadorAsignado { get; set; }
        public string? FilterGirador { get; set; }
        public string? FilterFechaRegistro { get; set; }
        public string? FilterEstadoFondeo { get; set; }
        public int PageSize { get; set; }
        public string? Sorting { get; set; }
        public string? SortOrder { get; set; }
        public int IdEstado { get; set; }

        public class GetFondeoListAllQueryHandler : IRequestHandler<GetFondeoListAll, Response<IReadOnlyList<FondeoResponseDataTable>>>
        {
            private readonly IFondeoRepositoryAsync _FondeoRepositoryAsync;
            private readonly IMapper _mapper;
            public GetFondeoListAllQueryHandler(IFondeoRepositoryAsync FondeoRepositoryAsync, IMapper mapper)
            {
                _FondeoRepositoryAsync = FondeoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<FondeoResponseDataTable>>> Handle(GetFondeoListAll query, CancellationToken cancellationToken)
            {
                var request = _mapper.Map<FondeoRequestDataTable>(query);

                var giradorList = await _FondeoRepositoryAsync.GetListFondeo(request);

                return new Response<IReadOnlyList<FondeoResponseDataTable>>(giradorList);
            }
        }
    }
}
