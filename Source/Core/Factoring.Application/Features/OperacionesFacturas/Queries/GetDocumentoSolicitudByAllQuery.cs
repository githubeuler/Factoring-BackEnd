using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Queries
{
    public class GetDocumentoSolicitudByAllQuery : IRequest<Response<IEnumerable<DocumentoSolicitudOperacionListDto>>>
    {
        public int Id { get; set; }
        public class GetDocumentoSolicitudByAllQueryHandler : IRequestHandler<GetDocumentoSolicitudByAllQuery, Response<IEnumerable<DocumentoSolicitudOperacionListDto>>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            public GetDocumentoSolicitudByAllQueryHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }
            public async Task<Response<IEnumerable<DocumentoSolicitudOperacionListDto>>> Handle(GetDocumentoSolicitudByAllQuery query, CancellationToken cancellationToken)
            {
                var giradorDirecciones = await _operacionesFacturaRepositoryAsync.GetDocumentoBySolicitud(query.Id);
                if (giradorDirecciones == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<DocumentoSolicitudOperacionListDto>>(giradorDirecciones);
            }
        }
    }
}
