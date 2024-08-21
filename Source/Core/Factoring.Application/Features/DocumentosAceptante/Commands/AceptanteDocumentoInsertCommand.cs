using AutoMapper;
using Factoring.Application.DTOs.DocumentosAceptante;
using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Features.GiradorDetails.Documentos.Commands.GiradorDocumentoInsertCommand;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.DocumentosAceptante.Commands
{
    public class AceptanteDocumentoInsertCommand : IRequest<Response<int>>
    {
        public int IdTipoDocumento { get; set; }
        public string Ruta { get; set; }
        public int IdAceptante { get; set; }
        public string NombreDocumento { get; set; }
    }

    public class AceptanteDocumentoInsertCommandHandler : IRequestHandler<AceptanteDocumentoInsertCommand, Response<int>>
    {
        private readonly IAceptanteDocumentoRepositoryAsync _aceptanteDocumentoRepositoryAsync;
        private readonly IMapper _mapper;

        public AceptanteDocumentoInsertCommandHandler(IAceptanteDocumentoRepositoryAsync aceptanteDocumentoRepositoryAsync, IMapper mapper)
        {
            _aceptanteDocumentoRepositoryAsync = aceptanteDocumentoRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AceptanteDocumentoInsertCommand request, CancellationToken cancellationToken)
        {
            var documento = _mapper.Map<DocumentosAceptanteInsertDto>(request);
            var res = await _aceptanteDocumentoRepositoryAsync.AddAsync(documento);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}
