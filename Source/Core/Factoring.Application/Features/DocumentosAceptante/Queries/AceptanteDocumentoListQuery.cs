using Factoring.Application.DTOs.DocumentosAceptante;
using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Exceptions;
using Factoring.Application.Features.GiradorDetails.Documentos.Querys.GiradorDocumentoListQuery;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.DocumentosAceptante.Queries
{
    public class AceptanteDocumentoListQuery : IRequest<Response<IEnumerable<DocumentosAceptanteListDto>>>
    {
        public int Id { get; set; }
        public class AceptanteDocumentoListQueryHandler : IRequestHandler<AceptanteDocumentoListQuery, Response<IEnumerable<DocumentosAceptanteListDto>>>
        {
            private readonly IAceptanteDocumentoRepositoryAsync _aceptanteDocumentoRepositoryAsync;

            public AceptanteDocumentoListQueryHandler(IAceptanteDocumentoRepositoryAsync aceptanteDocumentoRepositoryAsync)
            {
                _aceptanteDocumentoRepositoryAsync = aceptanteDocumentoRepositoryAsync;
            }

            public async Task<Response<IEnumerable<DocumentosAceptanteListDto>>> Handle(AceptanteDocumentoListQuery query, CancellationToken cancellationToken)
            {
                var documentoGiradorList = await _aceptanteDocumentoRepositoryAsync.GetAllDocumentosByIdAceptante(query.Id);
                if (documentoGiradorList == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<DocumentosAceptanteListDto>>(documentoGiradorList);
            }
        }
    }
}