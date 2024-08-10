using Factoring.Application.DTOs.Fondeador.DocumentoFondeador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.FondeadorDetails.Documentos.Querys.GetAllFondeadorByIdFondeador
{
    public class GetAllDocumentoByIdFondeadorQuery : IRequest<Response<IEnumerable<DocumentosFondeadorResponseListDto>>>
    {
        public int Id { get; set; }
        public class GetAllDocumentoByIdFondeadorQueryHandler : IRequestHandler<GetAllDocumentoByIdFondeadorQuery, Response<IEnumerable<DocumentosFondeadorResponseListDto>>>
        {
            private readonly IFondeadorDocumentoRepositoryAsync _fondeadorDocumentoRepositoryAsync;

            public GetAllDocumentoByIdFondeadorQueryHandler(IFondeadorDocumentoRepositoryAsync fondeadorDocumentoRepositoryAsync)
            {
                _fondeadorDocumentoRepositoryAsync = fondeadorDocumentoRepositoryAsync;
            }

            public async Task<Response<IEnumerable<DocumentosFondeadorResponseListDto>>> Handle(GetAllDocumentoByIdFondeadorQuery query, CancellationToken cancellationToken)
            {
                var documentoFondeadorList = await _fondeadorDocumentoRepositoryAsync.GetAllDocumentosByIdGirador(query.Id);
                if (documentoFondeadorList == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<DocumentosFondeadorResponseListDto>>(documentoFondeadorList);
            }
        }
    }
}
