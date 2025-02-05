using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Adquiriente.Queries
{
    public class GetAdquirienteListAll : IRequest<Response<IReadOnlyList<AdquirienteResponseDataTable>>>
    {
        public int Pageno { get; set; }
        public string? FilterRuc { get; set; }
        public string? FilterRazon { get; set; }
        public int FilterIdPais { get; set; }
        public string? FilterFecCrea { get; set; }
        public int FilterIdSector { get; set; }
        public int FilterIdGrupoEconomico { get; set; }
        public string Usuario { get; set; }
        public int PageSize { get; set; }
        public string? Sorting { get; set; }
        public string? SortOrder { get; set; }

        public class GetAdquirienteListAllQueryHandler : IRequestHandler<GetAdquirienteListAll, Response<IReadOnlyList<AdquirienteResponseDataTable>>>
        {
            private readonly IAdquirienteRepositoryAsync _adquirienteRepositoryAsync;
            private readonly IMapper _mapper;
            public GetAdquirienteListAllQueryHandler(IAdquirienteRepositoryAsync adquirienteRepositoryAsync, IMapper mapper)
            {
                _adquirienteRepositoryAsync = adquirienteRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<AdquirienteResponseDataTable>>> Handle(GetAdquirienteListAll query, CancellationToken cancellationToken)
            {
                var request = _mapper.Map<AdquirienteRequestDataTable>(query);

                var giradorList = await _adquirienteRepositoryAsync.GetListAdquiriente(request);

                return new Response<IReadOnlyList<AdquirienteResponseDataTable>>(giradorList);
            }
        }

    }
}
