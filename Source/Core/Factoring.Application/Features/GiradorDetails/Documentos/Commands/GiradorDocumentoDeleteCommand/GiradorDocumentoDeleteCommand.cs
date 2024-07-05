using AutoMapper;
using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.Documentos.Commands.GiradorDocumentoDeleteCommand
{
    public class GiradorDocumentoDeleteCommand : IRequest<Response<int>>
    {
        public int IdGiradorDocumento { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class GiradorDocumentoDeleteCommandHandler : IRequestHandler<GiradorDocumentoDeleteCommand, Response<int>>
        {
            private readonly IGiradorDocumentoRepositoryAsync _giradorDocumentoRepositoryAsync;
            private readonly IMapper _mapper;

            public GiradorDocumentoDeleteCommandHandler(IGiradorDocumentoRepositoryAsync giradorDocumentoRepositoryAsync, IMapper mapper)
            {
                _giradorDocumentoRepositoryAsync = giradorDocumentoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(GiradorDocumentoDeleteCommand command, CancellationToken cancellationToken)
            {
                var documentoEntry = _mapper.Map<DocumentosGiradorDeleteDto>(command);
                await _giradorDocumentoRepositoryAsync.DeleteAsync(documentoEntry);
                return new Response<int>(command.IdGiradorDocumento, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}