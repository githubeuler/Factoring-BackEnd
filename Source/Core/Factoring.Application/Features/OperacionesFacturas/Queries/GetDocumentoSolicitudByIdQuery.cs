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
    public class GetDocumentoSolicitudByIdQuery : IRequest<Response<IEnumerable<DocumentoSolicitudOperacionListIdDto>>>
    {
        public int IdSolEvalOperacion { get; set; }
        public class GetDocumentoSolicitudByIdQueryHandler : IRequestHandler<GetDocumentoSolicitudByIdQuery, Response<IEnumerable<DocumentoSolicitudOperacionListIdDto>>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;

            public GetDocumentoSolicitudByIdQueryHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }

            public async Task<Response<IEnumerable<DocumentoSolicitudOperacionListIdDto>>> Handle(GetDocumentoSolicitudByIdQuery query, CancellationToken cancellationToken)
            {
                var giradorDirecciones = await _operacionesFacturaRepositoryAsync.GetAllDocumentoSolicitudByOperaciones(query.IdSolEvalOperacion);
                if (giradorDirecciones == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<DocumentoSolicitudOperacionListIdDto>>(giradorDirecciones);
            }
        }
    }
}