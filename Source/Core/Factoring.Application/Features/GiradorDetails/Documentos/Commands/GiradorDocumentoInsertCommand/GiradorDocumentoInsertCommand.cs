using AutoMapper;
using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.Documentos.Commands.GiradorDocumentoInsertCommand
{
    public class GiradorDocumentoInsertCommand : IRequest<Response<int>>
    {
        public int IdTipoDocumento { get; set; }
        public string Ruta { get; set; }
        public int IdGirador { get; set; }
        public string NombreDocumento { get; set; }
    }

    public class GiradorDocumentoInsertCommandHandler : IRequestHandler<GiradorDocumentoInsertCommand, Response<int>>
    {
        private readonly IGiradorDocumentoRepositoryAsync _giradorDocumentoRepositoryAsync;
        private readonly IMapper _mapper;

        public GiradorDocumentoInsertCommandHandler(IGiradorDocumentoRepositoryAsync giradorDocumentoRepositoryAsync, IMapper mapper)
        {
            _giradorDocumentoRepositoryAsync = giradorDocumentoRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(GiradorDocumentoInsertCommand request, CancellationToken cancellationToken)
        {
            var documento = _mapper.Map<DocumentosGiradorInsertDto>(request);
            var res = await _giradorDocumentoRepositoryAsync.AddAsync(documento);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}
