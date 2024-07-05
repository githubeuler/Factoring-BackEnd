using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Girador.Queries
{
    public class GetGiradorDocumentosFileName : IRequest<Response<GetGiradorDocumentosFileName>>
    {
        public int IdDocumento { get; set; }
        public int IdTipo { get; set; }
        public string? FileName { get; set; }
        public string? Ruta { get; set; }
        public class GetGiradorDocumentosFileNameHandler : IRequestHandler<GetGiradorDocumentosFileName, Response<GetGiradorDocumentosFileName>>
        {
            private readonly IGiradorRepositoryAsync _giradorRepositoryAsync;

            public GetGiradorDocumentosFileNameHandler(
                IGiradorRepositoryAsync giradorRepositoryAsync
                )
            {
                _giradorRepositoryAsync = giradorRepositoryAsync;
            }

            public async Task<Response<GetGiradorDocumentosFileName>> Handle(GetGiradorDocumentosFileName query, CancellationToken cancellationToken)
            {
                var giradorDocumentos = await _giradorRepositoryAsync.GetDocumentosFileName(query.IdDocumento, query.IdTipo);

                return new Response<GetGiradorDocumentosFileName>(giradorDocumentos);
            }
        }
    }
}