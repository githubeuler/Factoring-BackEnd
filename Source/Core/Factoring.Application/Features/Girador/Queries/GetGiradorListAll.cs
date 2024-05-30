using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.DTOs.Girador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Girador.Queries
{
    public class GetGiradorListAll : IRequest<Response<IReadOnlyList<GiradorResponseDataTable>>>
    {
        public int Pageno { get; set; }
        public string? FilterRuc { get; set; }
        public string? FilterRazon { get; set; }
        public int FilterIdPais { get; set; }
        public string? FilterFecCrea { get; set; }
        public int FilterIdSector { get; set; }
        public int FilterIdGrupoEconomico { get; set; }
        public int PageSize { get; set; }
        public string? Sorting { get; set; }
        public string? SortOrder { get; set; }

        public class GetGiradorListAllQueryHandler : IRequestHandler<GetGiradorListAll, Response<IReadOnlyList<GiradorResponseDataTable>>>
        {
            private readonly IGiradorRepositoryAsync _giradorRepositoryAsync;
            private readonly IMapper _mapper;
            public GetGiradorListAllQueryHandler(IGiradorRepositoryAsync giradorRepositoryAsync, IMapper mapper)
            {
                _giradorRepositoryAsync = giradorRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<GiradorResponseDataTable>>> Handle(GetGiradorListAll query, CancellationToken cancellationToken)
            {

                var request = _mapper.Map<GiradorRequestDataTable>(query);

                var giradorList = await _giradorRepositoryAsync.GetListGirador(request);

                return new Response<IReadOnlyList<GiradorResponseDataTable>>(giradorList);
            }
        }

    }
}

