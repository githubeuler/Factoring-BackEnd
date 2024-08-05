using AutoMapper;
using Factoring.Application.DTOs.Fondeador.ControlFileFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Queries.FondeadorReportExport
{
    public class GetListControlFileFondeadorExportQuery : IRequest<Response<IReadOnlyList<FileExportFondeadorResponseDto>>>
    {
        public string Doi { get; set; }
        public string Razon { get; set; }
        public string FechaCreacion { get; set; }

        public class GetListControlFileFondeadorExportQueryHandler : IRequestHandler<GetListControlFileFondeadorExportQuery, Response<IReadOnlyList<FileExportFondeadorResponseDto>>>
        {
            private readonly IFondeadorRepositoryAsync _fondeadorRepositoryAsync;
            private readonly IMapper _mapper;

            public GetListControlFileFondeadorExportQueryHandler(IFondeadorRepositoryAsync fondeadorRepositoryAsync, IMapper mapper)
            {
                _fondeadorRepositoryAsync = fondeadorRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<FileExportFondeadorResponseDto>>> Handle(GetListControlFileFondeadorExportQuery request, CancellationToken cancellationToken)
            {
                var _request = _mapper.Map<FileExportFondeadorRequestDto>(request);
                var response = await _fondeadorRepositoryAsync.GetListFileExport(_request);
                return new Response<IReadOnlyList<FileExportFondeadorResponseDto>>(response);
            }
        }
    }
}
