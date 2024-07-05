using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.Documentos.Querys.GiradorDocumentoListQuery
{
    public class GiradorDocumentoListQuery : IRequest<Response<IEnumerable<DocumentosGiradorListDto>>>
    {
        public int Id { get; set; }
        public class GiradorDocumentoListQueryHandler : IRequestHandler<GiradorDocumentoListQuery, Response<IEnumerable<DocumentosGiradorListDto>>>
        {
            private readonly IGiradorDocumentoRepositoryAsync _giradorDocumentoRepositoryAsync;

            public GiradorDocumentoListQueryHandler(IGiradorDocumentoRepositoryAsync giradorDocumentoRepositoryAsync)
            {
                _giradorDocumentoRepositoryAsync = giradorDocumentoRepositoryAsync;
            }

            public async Task<Response<IEnumerable<DocumentosGiradorListDto>>> Handle(GiradorDocumentoListQuery query, CancellationToken cancellationToken)
            {
                var documentoGiradorList = await _giradorDocumentoRepositoryAsync.GetAllDocumentosByIdGirador(query.Id);
                if (documentoGiradorList == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<DocumentosGiradorListDto>>(documentoGiradorList);
            }
        }
    }
}