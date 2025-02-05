using AutoMapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Util;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Queries.FondeadorSearch
{
    public class GetFondeadorListAll : IRequest<Response<IReadOnlyList<FondeadorResponseDataTable>>>
    {
        public int Pageno { get; set; }
        public string? FilterDoi { get; set; }
        public string? FilterRazon { get; set; }
        public string? FilterFecCrea { get; set; }
        public string Usuario { get; set; }
        public int PageSize { get; set; }
        public string? Sorting { get; set; }
        public string? SortOrder { get; set; }
        public int IdEstado { get; set; }

        public class GetFondeadorListAllQueryHandler : IRequestHandler<GetFondeadorListAll, Response<IReadOnlyList<FondeadorResponseDataTable>>>
        {
            private readonly IFondeadorRepositoryAsync _fondeadorRepositoryAsync;
            private readonly IMapper _mapper;
            public GetFondeadorListAllQueryHandler(IFondeadorRepositoryAsync fondeadorRepositoryAsync, IMapper mapper)
            {
                _fondeadorRepositoryAsync = fondeadorRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<FondeadorResponseDataTable>>> Handle(GetFondeadorListAll query, CancellationToken cancellationToken)
            {
                LogUtil.GetLogger().Info($"Iniciando GetFondeadorListAllQuery - request : {query.ToJson()}");
                var request = _mapper.Map<FondeadorRequestDataTable>(query);

                var giradorList = await _fondeadorRepositoryAsync.GetListFondeador(request);

                return new Response<IReadOnlyList<FondeadorResponseDataTable>>(giradorList);
            }
        }
    }
}