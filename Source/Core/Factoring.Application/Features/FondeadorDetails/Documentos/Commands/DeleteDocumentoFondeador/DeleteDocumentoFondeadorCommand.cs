using AutoMapper;
using Factoring.Application.DTOs.Fondeador.DocumentoFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.FondeadorDetails.Documentos.Commands.DeleteDocumentoFondeador
{
    public class DeleteDocumentoFondeadorCommand : IRequest<Response<int>>
    {
        public int IdFondeadorDocumento { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class DeleteDocumentoFondeadorCommandHandler : IRequestHandler<DeleteDocumentoFondeadorCommand, Response<int>>
        {
            private readonly IFondeadorDocumentoRepositoryAsync _fondeadorDocumentoRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteDocumentoFondeadorCommandHandler(IFondeadorDocumentoRepositoryAsync fondeadorDocumentoRepositoryAsync, IMapper mapper)
            {
                _fondeadorDocumentoRepositoryAsync = fondeadorDocumentoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteDocumentoFondeadorCommand command, CancellationToken cancellationToken)
            {
                var documentoEntry = _mapper.Map<DocumentosFondeadorDeleteDto>(command);
                await _fondeadorDocumentoRepositoryAsync.DeleteAsync(documentoEntry);
                return new Response<int>(command.IdFondeadorDocumento, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}
