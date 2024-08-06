using AutoMapper;
using Factoring.Application.DTOs.Fondeador.DocumentoFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.FondeadorDetails.Documentos.Commands.CreateDocumentoFondeador
{
    public class CreateFondeadorDocumentoCommand : IRequest<Response<int>>
    {
        public string RutaDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string UsuarioCreador { get; set; }
        public int IdFondeador { get; set; }
    }

    public class CreateFondeadorDocumentoCommandHandler : IRequestHandler<CreateFondeadorDocumentoCommand, Response<int>>
    {
        private readonly IFondeadorDocumentoRepositoryAsync _fondeadorDocumentoRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateFondeadorDocumentoCommandHandler(IFondeadorDocumentoRepositoryAsync fondeadorDocumentoRepositoryAsync, IMapper mapper)
        {
            _fondeadorDocumentoRepositoryAsync = fondeadorDocumentoRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFondeadorDocumentoCommand request, CancellationToken cancellationToken)
        {
            var documento = _mapper.Map<DocumentosFondeadorCreateDto>(request);
            var res = await _fondeadorDocumentoRepositoryAsync.AddAsync(documento);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}
