using AutoMapper;
using Factoring.Application.DTOs.DocumentosAceptante;
using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Features.GiradorDetails.Documentos.Commands.GiradorDocumentoDeleteCommand;
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
    public class AceptanteDocumentoDeleteCommand : IRequest<Response<int>>
    {
        public int IdAceptanteDocumento { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class AceptanteDocumentoDeleteCommandHandler : IRequestHandler<AceptanteDocumentoDeleteCommand, Response<int>>
        {
            private readonly IAceptanteDocumentoRepositoryAsync _aceptanteDocumentoRepositoryAsync;
            private readonly IMapper _mapper;

            public AceptanteDocumentoDeleteCommandHandler(IAceptanteDocumentoRepositoryAsync aceptanteDocumentoRepositoryAsync, IMapper mapper)
            {
                _aceptanteDocumentoRepositoryAsync = aceptanteDocumentoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(AceptanteDocumentoDeleteCommand command, CancellationToken cancellationToken)
            {
                var documentoEntry = _mapper.Map<DocumentosAceptanteDeleteDto>(command);
                await _aceptanteDocumentoRepositoryAsync.DeleteAsync(documentoEntry);
                return new Response<int>(command.IdAceptanteDocumento, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}